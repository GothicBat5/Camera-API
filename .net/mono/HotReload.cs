using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mono.HotReload;

internal sealed class InstanceFieldTable
{
    internal static FieldStore GetInstanceFieldFieldStore(object inst, IntPtr type, uint fielddef_token)
    {
        return _singleton.GetOrCreateInstanceFields(inst).LookupOrAdd(new RuntimeTypeHandle(type), fielddef_token);
    }

    private static readonly InstanceFieldTable _singleton = new();

    private readonly ConditionalWeakTable<object, InstanceFields> _table;

    private InstanceFieldTable()
    {
        _table = new();
    }

    private InstanceFields GetOrCreateInstanceFields(object key)
        => _table.GetOrCreateValue(key);

    private sealed class InstanceFields
    {
        private readonly Dictionary<uint, FieldStore> _fields;
        private readonly object _lock;

        public InstanceFields()
        {
            _fields = new();
            _lock = new();
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode",
            Justification = "Hot reload required untrimmed apps")]
        public FieldStore LookupOrAdd(RuntimeTypeHandle type, uint key)
        {
            if (_fields.TryGetValue(key, out FieldStore? v))
                return v;
            lock (_lock)
            {
                if (_fields.TryGetValue(key, out FieldStore? v2))
                    return v2;

                FieldStore s = FieldStore.Create(type);
                _fields.Add(key, s);
                return s;
            }
        }
    }

}

[StructLayout(LayoutKind.Sequential)]
internal sealed class FieldStore
{
    private readonly object? _loc;

    private FieldStore(object? loc)
    {
        _loc = loc;
    }

    [RequiresUnreferencedCode("Hot reload required untrimmed apps")]
    public static FieldStore Create(RuntimeTypeHandle type)
    {
        Type t = Type.GetTypeFromHandle(type) ?? throw new ArgumentException(SR.Arg_InvalidHandle, nameof(type));
        object? loc;
        if (t.IsPrimitive || t.IsValueType) loc = RuntimeHelpers.GetUninitializedObject(t);
        else if (t.IsClass || t.IsInterface) loc = null;
        else throw new ArgumentException(SR.Arg_EnC_ExpectedPrimitive);
        /* FIXME: do we want FieldStore to be pinned? */
        return new FieldStore(loc);
    }
}
