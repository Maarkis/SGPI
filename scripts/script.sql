CREATE TABLE financial_products (
    id uuid NOT NULL,
    name character varying(100) NOT NULL,
    type character varying(100) NOT NULL,
    value numeric NOT NULL,
    maturity_date timestamp with time zone NOT NULL,
    interest_rate double precision NOT NULL,
    product_code character varying(30) NOT NULL,
    create_at timestamp with time zone NOT NULL,
    update_at timestamp with time zone,
    enabled boolean NOT NULL,
    CONSTRAINT "PK_financial_products" PRIMARY KEY (id)
);


