-- public.countries definition

-- Drop table

-- DROP TABLE countries;

CREATE TABLE countries (
	id int4 DEFAULT nextval('country_id_seq'::regclass) NOT NULL,
	"name" varchar(100) NOT NULL,
	spanish_name varchar(100) NOT NULL,
	population int8 NULL,
	surface varchar(255) NULL,
	independence_day timestamptz NULL,
	goverment_id int8 NOT NULL,
	language_id int8 NOT NULL,
	continent_id int8 NOT NULL,
	anthem_id int8 NOT NULL,
	symbol_id int8 NULL,
	CONSTRAINT country_pkey PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE countries OWNER TO postgres;
GRANT ALL ON TABLE countries TO postgres;


-- public.countries foreign keys

ALTER TABLE public.countries ADD CONSTRAINT country_anthem_fk FOREIGN KEY (anthem_id) REFERENCES anthems(id);