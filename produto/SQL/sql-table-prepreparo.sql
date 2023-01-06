CREATE TABLE public.prepreparo (
	prepreparoid uuid NOT NULL,
	produtoid uuid NOT NULL,
	reindimento decimal NULL,
	dataalteracao timestamptz NULL,
	datacadastro timestamptz NULL,
	excluido bool NULL,
	CONSTRAINT prepreparo_pk PRIMARY KEY (prepreparoid)
);
CREATE UNIQUE INDEX prepreparo_prepreparoid_idx ON public.prepreparo USING btree (prepreparoid);


-- public.produto foreign keys

ALTER TABLE public.prepreparo ADD CONSTRAINT prepreparo_fk FOREIGN KEY (produtoid) REFERENCES public.produto(produtoid);
