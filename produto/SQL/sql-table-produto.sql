CREATE TABLE public.produto (
	produtoid uuid NOT NULL,
	nome varchar(90) NULL,
	descricao varchar(180) NULL,
	cest varchar(30) NULL,
	ncm varchar(30) NULL,
	qtditenscontidos numeric NULL,
	codigobarras varchar(30) NULL,
	tipo int4 NULL,
	dataalteracao timestamptz NULL,
	datacadastro timestamptz NULL,
	excluido bool NULL,
	marcaid uuid NULL,
	unidademedida int4 NULL,
	CONSTRAINT produto_pk PRIMARY KEY (produtoid)
);
CREATE UNIQUE INDEX produto_produtoid_idx ON public.produto USING btree (produtoid);


-- public.produto foreign keys

ALTER TABLE public.produto ADD CONSTRAINT produto_fk FOREIGN KEY (marcaid) REFERENCES public.marca(marcaid);