-- public.anthems definition

-- Drop table

-- DROP TABLE anthems;

CREATE TABLE anthems (
	id int4 DEFAULT nextval('anthem_id_seq'::regclass) NOT NULL,
	motto varchar(1000) NULL,
	"content" text NOT NULL,
	CONSTRAINT anthem_pkey PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE anthems OWNER TO postgres;
GRANT ALL ON TABLE anthems TO postgres;