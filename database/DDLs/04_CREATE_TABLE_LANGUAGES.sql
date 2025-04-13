-- public.languages definition

-- Drop table

-- DROP TABLE languages;

CREATE TABLE languages (
	id int4 DEFAULT nextval('language_id_seq'::regclass) NOT NULL,
	"name" varchar(50) NULL,
	CONSTRAINT language_pkey PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE languages OWNER TO postgres;
GRANT ALL ON TABLE languages TO postgres;