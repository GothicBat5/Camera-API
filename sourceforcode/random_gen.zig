const std = @import("std");

pub fn main() !void {
    var rng = std.crypto.random;
    const num = rng.int(u32);
    std.debug.print("Random u32: {}\n", .{num});

    const f = rng.float(f32);
    std.debug.print("Random f32: {}\n", .{f});

    const b = rng.bool(bool);
    std.debug.print("Random bool: {}\n", .{b});

    const range = rng.intRangeAtMost(u32, 1, 100);
    std.debug.print("Random 1-100: {}\n", .{range});

    var items = [_]i32{ 1, 2, 3, 4, 5 };
    rng.shuffle(i32, &items, null);
    std.debug.print("Shuffled: {any}\n", .{items});

    const choice = items[rng.intRangeAtMost(usize, 0, items.len - 1)];
    std.debug.print("Chosen: {}\n", .{choice});
}
