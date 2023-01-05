CREATE TABLE public.produtoprepreparo (
	produtoprepreparoid uuid NOT NULL,
	produtoid uuid NOT NULL,
	quantidade decimal NULL,
	dataalteracao timestamptz NULL,
	datacadastro timestamptz NULL,
	excluido bool NULL,
	unidademedida int4 NULL,
	CONSTRAINT produtoprepreparo_pk PRIMARY KEY (produtoprepreparoid)
);
CREATE UNIQUE INDEX produtoprepreparo_produtoprepreparoid_idx ON public.produtoprepreparo USING btree (produtoprepreparoid);


-- public.produto foreign keys

ALTER TABLE public.produtoprepreparo ADD CONSTRAINT produtoprepreparo_fk FOREIGN KEY (produtoid) REFERENCES public.produto(produtoid);