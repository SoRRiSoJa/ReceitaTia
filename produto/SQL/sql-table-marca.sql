CREATE TABLE public.marca (
	marcaid uuid NULL,
	nome varchar(100) NULL,
	dataalteracao timestamp with time zone NULL,
	datacadastro timestamp with time zone NULL,
	excluido bool NULL,
	CONSTRAINT marca_pk PRIMARY KEY (marcaid)
);
CREATE UNIQUE INDEX marca_marcaid_idx ON public.marca (marcaid);