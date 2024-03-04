BEGIN TRANSACTION;

CREATE TABLE "ef_temp_Comments" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Comments" PRIMARY KEY,
    "BlogId" TEXT NOT NULL,
    "Text" TEXT NOT NULL,
    CONSTRAINT "FK_Comments_Blogs_BlogId" FOREIGN KEY ("BlogId") REFERENCES "Blogs" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_Comments" ("Id", "BlogId", "Text")
SELECT "Id", "BlogId", "Text"
FROM "Comments";

CREATE TABLE "ef_temp_Blogs" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY,
    "Content" TEXT NOT NULL,
    "PriceOfSubscription" INTEGER NOT NULL,
    "Title" TEXT NOT NULL
);

INSERT INTO "ef_temp_Blogs" ("Id", "Content", "PriceOfSubscription", "Title")
SELECT "Id", "Content", "PriceOfSubscription", "Title"
FROM "Blogs";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Comments";

ALTER TABLE "ef_temp_Comments" RENAME TO "Comments";

DROP TABLE "Blogs";

ALTER TABLE "ef_temp_Blogs" RENAME TO "Blogs";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Comments_BlogId" ON "Comments" ("BlogId");

DELETE FROM "__EFMigrationsHistory"
WHERE "MigrationId" = '20240304095228_RefactorBlogAndComment';

COMMIT;

