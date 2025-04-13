-- public.continents definition

-- Drop table

-- DROP TABLE continents;

CREATE TABLE continents (
	id int4 DEFAULT nextval('continent_id_seq'::regclass) NOT NULL,
	"name" varchar(50) NULL,
	CONSTRAINT continent_pkey PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE continents OWNER TO postgres;
GRANT ALL ON TABLE continents TO postgres;