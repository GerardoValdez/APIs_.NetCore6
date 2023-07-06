--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-06-09 17:30:42

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 24645)
-- Name: deportes; Type: TABLE; Schema: public; Owner: geraValdez
--

CREATE TABLE public.deportes (
    "Id" uuid NOT NULL,
    deporte text NOT NULL,
    descripcion text NOT NULL,
    "IdTipoDeporte" uuid NOT NULL
);


ALTER TABLE public.deportes OWNER TO "geraValdez";

--
-- TOC entry 216 (class 1259 OID 24625)
-- Name: personas; Type: TABLE; Schema: public; Owner: geraValdez
--

CREATE TABLE public.personas (
    "Id" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "Apellido" text NOT NULL,
    "Dni" text NOT NULL,
    "IdSexo" uuid NOT NULL,
    "Calle" text NOT NULL,
    "Numero" text NOT NULL
);


ALTER TABLE public.personas OWNER TO "geraValdez";

--
-- TOC entry 215 (class 1259 OID 24612)
-- Name: roles; Type: TABLE; Schema: public; Owner: geraValdez
--

CREATE TABLE public.roles (
    "Id" uuid NOT NULL,
    "Rol" text NOT NULL,
    "Descripcion" text NOT NULL
);


ALTER TABLE public.roles OWNER TO "geraValdez";

--
-- TOC entry 217 (class 1259 OID 24632)
-- Name: sexos; Type: TABLE; Schema: public; Owner: geraValdez
--

CREATE TABLE public.sexos (
    "Id" uuid NOT NULL,
    sexo text NOT NULL
);


ALTER TABLE public.sexos OWNER TO "geraValdez";

--
-- TOC entry 219 (class 1259 OID 24652)
-- Name: tipoDeportes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tipoDeportes" (
    "Id" uuid NOT NULL,
    "tipoDeporte" text NOT NULL
);


ALTER TABLE public."tipoDeportes" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 24605)
-- Name: usuarios; Type: TABLE; Schema: public; Owner: geraValdez
--

CREATE TABLE public.usuarios (
    "Id" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "Password" text NOT NULL,
    "FechaAlta" date NOT NULL,
    "Activo" boolean NOT NULL,
    "IdRol" uuid NOT NULL
);


ALTER TABLE public.usuarios OWNER TO "geraValdez";

--
-- TOC entry 3356 (class 0 OID 24645)
-- Dependencies: 218
-- Data for Name: deportes; Type: TABLE DATA; Schema: public; Owner: geraValdez
--

COPY public.deportes ("Id", deporte, descripcion, "IdTipoDeporte") FROM stdin;
\.


--
-- TOC entry 3354 (class 0 OID 24625)
-- Dependencies: 216
-- Data for Name: personas; Type: TABLE DATA; Schema: public; Owner: geraValdez
--

COPY public.personas ("Id", "Nombre", "Apellido", "Dni", "IdSexo", "Calle", "Numero") FROM stdin;
\.


--
-- TOC entry 3353 (class 0 OID 24612)
-- Dependencies: 215
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: geraValdez
--

COPY public.roles ("Id", "Rol", "Descripcion") FROM stdin;
ee4bf95b-1244-42f9-956f-12f87903050a	Administrador	Usuario Administrador
aed46536-2873-4154-881f-85b01f9bdc3d	Cliente	Usuario Cliente
7f10d3e6-3ebc-48e4-9006-2cd1c9ef9ed0	Vendedor	Usuario Vendedor
\.


--
-- TOC entry 3355 (class 0 OID 24632)
-- Dependencies: 217
-- Data for Name: sexos; Type: TABLE DATA; Schema: public; Owner: geraValdez
--

COPY public.sexos ("Id", sexo) FROM stdin;
\.


--
-- TOC entry 3357 (class 0 OID 24652)
-- Dependencies: 219
-- Data for Name: tipoDeportes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tipoDeportes" ("Id", "tipoDeporte") FROM stdin;
4afee696-784c-4413-be05-4317bd233b36	Individual
f768bac1-0da0-4947-88ea-043ed3ed9b09	Grupal
f2e55a9f-68e2-40d6-b386-907e16e2b951	Otro
\.


--
-- TOC entry 3352 (class 0 OID 24605)
-- Dependencies: 214
-- Data for Name: usuarios; Type: TABLE DATA; Schema: public; Owner: geraValdez
--

COPY public.usuarios ("Id", "Nombre", "Password", "FechaAlta", "Activo", "IdRol") FROM stdin;
\.


--
-- TOC entry 3203 (class 2606 OID 24651)
-- Name: deportes deportes_pkey; Type: CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.deportes
    ADD CONSTRAINT deportes_pkey PRIMARY KEY ("IdTipoDeporte");


--
-- TOC entry 3199 (class 2606 OID 24631)
-- Name: personas personas_pkey; Type: CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.personas
    ADD CONSTRAINT personas_pkey PRIMARY KEY ("Id");


--
-- TOC entry 3196 (class 2606 OID 24618)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY ("Id");


--
-- TOC entry 3201 (class 2606 OID 24636)
-- Name: sexos sexos_pkey; Type: CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.sexos
    ADD CONSTRAINT sexos_pkey PRIMARY KEY ("Id");


--
-- TOC entry 3206 (class 2606 OID 24658)
-- Name: tipoDeportes tipoDeportes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tipoDeportes"
    ADD CONSTRAINT "tipoDeportes_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 3194 (class 2606 OID 24611)
-- Name: usuarios usuarios_pkey; Type: CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT usuarios_pkey PRIMARY KEY ("Id");


--
-- TOC entry 3192 (class 1259 OID 24624)
-- Name: fki_fk_rol; Type: INDEX; Schema: public; Owner: geraValdez
--

CREATE INDEX fki_fk_rol ON public.usuarios USING btree ("IdRol");


--
-- TOC entry 3197 (class 1259 OID 24644)
-- Name: fki_fk_sexo; Type: INDEX; Schema: public; Owner: geraValdez
--

CREATE INDEX fki_fk_sexo ON public.personas USING btree ("IdSexo");


--
-- TOC entry 3204 (class 1259 OID 24664)
-- Name: fki_fk_tipoDeporte; Type: INDEX; Schema: public; Owner: geraValdez
--

CREATE INDEX "fki_fk_tipoDeporte" ON public.deportes USING btree ("IdTipoDeporte");


--
-- TOC entry 3207 (class 2606 OID 24619)
-- Name: usuarios fk_rol; Type: FK CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT fk_rol FOREIGN KEY ("IdRol") REFERENCES public.roles("Id") NOT VALID;


--
-- TOC entry 3208 (class 2606 OID 24639)
-- Name: personas fk_sexo; Type: FK CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.personas
    ADD CONSTRAINT fk_sexo FOREIGN KEY ("IdSexo") REFERENCES public.sexos("Id") NOT VALID;


--
-- TOC entry 3209 (class 2606 OID 24659)
-- Name: deportes fk_tipoDeporte; Type: FK CONSTRAINT; Schema: public; Owner: geraValdez
--

ALTER TABLE ONLY public.deportes
    ADD CONSTRAINT "fk_tipoDeporte" FOREIGN KEY ("IdTipoDeporte") REFERENCES public."tipoDeportes"("Id") NOT VALID;


-- Completed on 2023-06-09 17:30:43

--
-- PostgreSQL database dump complete
--

