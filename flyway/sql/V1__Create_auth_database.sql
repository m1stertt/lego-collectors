CREATE TABLE "LoginUsers"
(
    "Id"             INTEGER NOT NULL
        CONSTRAINT "PK_LoginUsers" PRIMARY KEY AUTOINCREMENT,
    "Email"          TEXT    NOT NULL,
    "HashedPassword" BLOB    NOT NULL,
    "PasswordSalt"   BLOB    NOT NULL,
    "DbUserId"       INTEGER NOT NULL
);
CREATE TABLE "Permissions"
(
    "Id"          INTEGER NOT NULL
        CONSTRAINT "PK_Permissions" PRIMARY KEY AUTOINCREMENT,
    "Name"        TEXT    NOT NULL,
    "LoginUserId" INTEGER NULL,
    CONSTRAINT "FK_Permissions_LoginUsers_LoginUserId" FOREIGN KEY ("LoginUserId") REFERENCES "LoginUsers" ("Id")
);
CREATE TABLE "UserPermissions"
(
    "UserId"       INTEGER NOT NULL,
    "PermissionId" INTEGER NOT NULL,
    CONSTRAINT "PK_UserPermissions" PRIMARY KEY ("PermissionId", "UserId"),
    CONSTRAINT "FK_UserPermissions_LoginUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "LoginUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserPermissions_Permissions_PermissionId" FOREIGN KEY ("PermissionId") REFERENCES "Permissions" ("Id") ON DELETE CASCADE
);