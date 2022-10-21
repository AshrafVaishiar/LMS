﻿using ErrorOr;

namespace lms.api.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail",
                description: "Email already in use...");
        }
    }
}
