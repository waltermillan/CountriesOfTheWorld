-- public.symbols definition

-- Drop table

-- DROP TABLE symbols;

CREATE TABLE symbols (
	id int4 NOT NULL,
	flag varchar NULL,
	coat_of_arms varchar NULL,
	CONSTRAINT symbols_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE symbols OWNER TO postgres;
GRANT ALL ON TABLE symbols TO postgres;