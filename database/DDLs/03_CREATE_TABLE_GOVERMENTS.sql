-- public.goverments definition

-- Drop table

-- DROP TABLE goverments;

CREATE TABLE goverments (
	id int4 DEFAULT nextval('goverment_id_seq'::regclass) NOT NULL,
	"name" varchar(50) NULL,
	CONSTRAINT goverment_pkey PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE goverments OWNER TO postgres;
GRANT ALL ON TABLE goverments TO postgres;