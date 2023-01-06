CREATE TABLE public.prepreparo_produtoprepreparo (
	prepreparoprodutoprepreparoid uuid NOT NULL,
	prepreparoid uuid NOT NULL,
	produtoprepreparoid uuid NOT NULL,
	CONSTRAINT prepreparoprodutoprepreparo PRIMARY KEY (prepreparoprodutoprepreparoid)
);

-- public.prepreparoprodutoprepreparo foreign keys

ALTER TABLE public.prepreparo_produtoprepreparo ADD CONSTRAINT ppprepreparo_fk FOREIGN KEY (prepreparoid) REFERENCES public.prepreparo(prepreparoid);
ALTER TABLE public.prepreparo_produtoprepreparo ADD CONSTRAINT ppprodutoprepreparo_fk FOREIGN KEY (produtoprepreparoid) REFERENCES public.produtoprepreparo(produtoprepreparoid);
