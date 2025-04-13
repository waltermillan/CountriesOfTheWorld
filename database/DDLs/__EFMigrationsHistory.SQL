-- public."__EFMigrationsHistory" definition

-- Drop table

-- DROP TABLE "__EFMigrationsHistory";

CREATE TABLE "__EFMigrationsHistory" (
	"MigrationId" varchar(150) NOT NULL,
	"ProductVersion" varchar(32) NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

-- Permissions

ALTER TABLE "__EFMigrationsHistory" OWNER TO postgres;
GRANT ALL ON TABLE "__EFMigrationsHistory" TO postgres;