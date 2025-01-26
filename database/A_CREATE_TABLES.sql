CREATE TABLE IF NOT EXISTS "country" (
	"id" serial NOT NULL UNIQUE,
	"name" varchar(100) NOT NULL,
	"spanish_name" varchar(100) NOT NULL,
	"population" bigint,
	"surface" varchar(255),
	"independence_day" timestamp with time zone,
	"goverment_id" bigint NOT NULL,
	"language_id" bigint NOT NULL,
	"continent_id" bigint NOT NULL,
	"anthem_id" bigint NOT NULL,
	PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS "continent" (
	"id" serial NOT NULL UNIQUE,
	"name" varchar(50),
	PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS "language" (
	"id" serial NOT NULL UNIQUE,
	"name" varchar(50),
	PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS "goverment" (
	"id" serial NOT NULL UNIQUE,
	"name" varchar(50),
	PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS "anthem" (
	"id" serial NOT NULL UNIQUE,
	"motto" varchar(50),
	"content" varchar(max) NOT NULL,
	PRIMARY KEY ("id")
);

ALTER TABLE "country" ADD CONSTRAINT "country_goverment_fk" FOREIGN KEY ("goverment_id") REFERENCES "goverment"("id");

ALTER TABLE "country" ADD CONSTRAINT "country_language_fk" FOREIGN KEY ("language_id") REFERENCES "language"("id");

ALTER TABLE "country" ADD CONSTRAINT "country_continent_fk" FOREIGN KEY ("continent_id") REFERENCES "continent"("id");

ALTER TABLE "country" ADD CONSTRAINT "country_anthem_fk" FOREIGN KEY ("anthem_id") REFERENCES "anthem"("id");



