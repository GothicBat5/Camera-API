const std = @import("std");

const Person = struct {
    name: []const u8,
    age: u8,
};

fn bubbleSortPeople(people: []Person) void {
    var n = people.len;

    while (n > 1) : (n -= 1) 
    {
        var i: usize = 0;

        while (i < n - 1) : (i += 1) 
        {
            if (people[i].age > people[i + 1].age) 
            {
                const temp = people[i];
                people[i] = people[i + 1];
                people[i + 1] = temp;
            }
        }
    }
}

pub fn main() !void {
    var people = [_]Person{.{ .name = "Alice", .age = 33 }, .{ .name = "Bob", .age = 18 }, .{ .name = "Charlie", .age = 25 },};

    bubbleSortPeople(people[0..]);

    for (people) |person|
    {
        std.debug.print("{s}: {d}\n",.{ person.name, person.age });
    }
}
