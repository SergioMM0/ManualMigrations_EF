BEGIN TRANSACTION;

ALTER TABLE "Comments" ADD "Signature" TEXT NOT NULL DEFAULT '';

CREATE TABLE "ef_temp_Blogs" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY,
    "Content" TEXT NOT NULL,
    "PriceOfSubscription" REAL NOT NULL,
    "Title" TEXT NOT NULL
);

INSERT INTO "ef_temp_Blogs" ("Id", "Content", "PriceOfSubscription", "Title")
SELECT "Id", "Content", "PriceOfSubscription", "Title"
FROM "Blogs";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Blogs";

ALTER TABLE "ef_temp_Blogs" RENAME TO "Blogs";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240304095228_RefactorBlogAndComment', '7.0.16');

COMMIT;

