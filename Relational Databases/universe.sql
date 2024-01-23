--
-- PostgreSQL database dump
--

-- Dumped from database version 12.9 (Ubuntu 12.9-2.pgdg20.04+1)
-- Dumped by pg_dump version 12.9 (Ubuntu 12.9-2.pgdg20.04+1)

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

DROP DATABASE universe;
--
-- Name: universe; Type: DATABASE; Schema: -; Owner: freecodecamp
--

CREATE DATABASE universe WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'C.UTF-8' LC_CTYPE = 'C.UTF-8';


ALTER DATABASE universe OWNER TO freecodecamp;

\connect universe

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
-- Name: asteroid; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.asteroid (
    asteroid_id integer NOT NULL,
    name character varying(30) NOT NULL,
    age_in_millions_of_years integer,
    distance_from_earth integer,
    size_in_ligthyears numeric,
    description text,
    has_life boolean,
    is_spherical boolean
);


ALTER TABLE public.asteroid OWNER TO freecodecamp;

--
-- Name: asteroid_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.asteroid_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.asteroid_id_seq OWNER TO freecodecamp;

--
-- Name: asteroid_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.asteroid_id_seq OWNED BY public.asteroid.asteroid_id;


--
-- Name: galaxy; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.galaxy (
    galaxy_id integer NOT NULL,
    name character varying(30) NOT NULL,
    age_in_millions_of_years integer,
    distance_from_earth integer,
    size_in_ligthyears numeric,
    description text,
    has_life boolean,
    is_spherical boolean
);


ALTER TABLE public.galaxy OWNER TO freecodecamp;

--
-- Name: galaxy_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.galaxy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.galaxy_id_seq OWNER TO freecodecamp;

--
-- Name: galaxy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.galaxy_id_seq OWNED BY public.galaxy.galaxy_id;


--
-- Name: moon; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.moon (
    moon_id integer NOT NULL,
    name character varying(30) NOT NULL,
    age_in_millions_of_years integer,
    distance_from_earth integer,
    size_in_ligthyears numeric,
    description text,
    has_life boolean,
    is_spherical boolean,
    planet_id integer
);


ALTER TABLE public.moon OWNER TO freecodecamp;

--
-- Name: moon_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.moon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.moon_id_seq OWNER TO freecodecamp;

--
-- Name: moon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.moon_id_seq OWNED BY public.moon.moon_id;


--
-- Name: planet; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.planet (
    planet_id integer NOT NULL,
    name character varying(30) NOT NULL,
    age_in_millions_of_years integer,
    distance_from_earth integer,
    size_in_ligthyears numeric,
    description text,
    has_life boolean,
    is_spherical boolean,
    star_id integer
);


ALTER TABLE public.planet OWNER TO freecodecamp;

--
-- Name: planet_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.planet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.planet_id_seq OWNER TO freecodecamp;

--
-- Name: planet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.planet_id_seq OWNED BY public.planet.planet_id;


--
-- Name: star; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.star (
    star_id integer NOT NULL,
    name character varying(30) NOT NULL,
    age_in_millions_of_years integer,
    distance_from_earth integer,
    size_in_ligthyears numeric,
    description text,
    has_life boolean,
    is_spherical boolean,
    galaxy_id integer
);


ALTER TABLE public.star OWNER TO freecodecamp;

--
-- Name: star_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.star_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.star_id_seq OWNER TO freecodecamp;

--
-- Name: star_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.star_id_seq OWNED BY public.star.star_id;


--
-- Name: asteroid asteroid_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.asteroid ALTER COLUMN asteroid_id SET DEFAULT nextval('public.asteroid_id_seq'::regclass);


--
-- Name: galaxy galaxy_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy ALTER COLUMN galaxy_id SET DEFAULT nextval('public.galaxy_id_seq'::regclass);


--
-- Name: moon moon_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon ALTER COLUMN moon_id SET DEFAULT nextval('public.moon_id_seq'::regclass);


--
-- Name: planet planet_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet ALTER COLUMN planet_id SET DEFAULT nextval('public.planet_id_seq'::regclass);


--
-- Name: star star_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star ALTER COLUMN star_id SET DEFAULT nextval('public.star_id_seq'::regclass);


--
-- Data for Name: asteroid; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.asteroid VALUES (1, 'Psyche', 0, 0, 0, 'Asteroid', false, false);
INSERT INTO public.asteroid VALUES (2, 'Eros', 0, 0, 0, 'Asteroid', false, false);
INSERT INTO public.asteroid VALUES (3, 'Bennu', 0, 0, 0, 'Asteroid', false, false);


--
-- Data for Name: galaxy; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.galaxy VALUES (1, 'Milky Way', 13800, 0, 87400, 'Our home', true, false);
INSERT INTO public.galaxy VALUES (2, 'Andromeda', 10000000, 2537000, 260000, 'Spiral galaxy', false, false);
INSERT INTO public.galaxy VALUES (3, 'Swirl Galaxy', 40030000, 23160000, 100000, 'Galaxy in the form of a swirl', false, false);
INSERT INTO public.galaxy VALUES (4, 'Orion Nebula', 300200000, 1344, 40, 'Brighest observable galaxy', false, false);
INSERT INTO public.galaxy VALUES (5, 'Triangle Galaxy', 15000000, 27230000, 60000, 'Spiral galaxy', false, false);
INSERT INTO public.galaxy VALUES (6, 'Magellanic Cloud', 1101000, 163000, 32500, 'Second closest galaxy', false, false);


--
-- Data for Name: moon; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.moon VALUES (1, 'Moon', 4503, 0, 0, 'Earths moon', false, true, 1);
INSERT INTO public.moon VALUES (2, 'Phobos', 4500, 0, 0, 'Mars moon', false, true, 4);
INSERT INTO public.moon VALUES (3, 'Deimos', 4500, 0, 0, 'Mars moon', false, true, 4);
INSERT INTO public.moon VALUES (4, 'Ganymede', 4500, 0, 0, 'Jupiter moon', false, true, 5);
INSERT INTO public.moon VALUES (5, 'Callisto', 4500, 0, 0, 'Jupiter moon', false, true, 5);
INSERT INTO public.moon VALUES (6, 'Io', 4500, 0, 0, 'Jupiter moon', false, true, 5);
INSERT INTO public.moon VALUES (7, 'Eurpa', 4500, 0, 0, 'Jupiter moon', false, true, 5);
INSERT INTO public.moon VALUES (8, 'Titan', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (9, 'Enceladus', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (10, 'Hyperion', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (11, 'Prometheus', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (12, 'Pandora', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (13, 'Janus', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (14, 'Epithemeus', 4500, 0, 0, 'Saturn moon', false, true, 6);
INSERT INTO public.moon VALUES (15, 'Miranda', 4500, 0, 0, 'Uranus moon', false, true, 7);
INSERT INTO public.moon VALUES (16, 'Ariel', 4500, 0, 0, 'Uranus moon', false, true, 7);
INSERT INTO public.moon VALUES (17, 'Umbriel', 4500, 0, 0, 'Uranus moon', false, true, 7);
INSERT INTO public.moon VALUES (18, 'Titania', 4500, 0, 0, 'Uranus moon', false, true, 7);
INSERT INTO public.moon VALUES (19, 'Despina', 4500, 0, 0, 'Neptune moon', false, true, 8);
INSERT INTO public.moon VALUES (20, 'Charon', 4500, 0, 0, 'Pluto moon', false, true, 9);


--
-- Data for Name: planet; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.planet VALUES (1, 'Earth', 4543, 0, 0, 'Our home', true, true, 1);
INSERT INTO public.planet VALUES (2, 'Mercury', 4503, 0, 0, 'Closest planet to the sun', false, true, 1);
INSERT INTO public.planet VALUES (3, 'Venus', 4503, 0, 0, 'Brightest object in our sky after the moon', false, true, 1);
INSERT INTO public.planet VALUES (4, 'Mars', 4603, 0, 0, 'The red planet', false, true, 1);
INSERT INTO public.planet VALUES (5, 'Jupiter', 4603, 0, 0, 'Biggest planet in our solar system', false, true, 1);
INSERT INTO public.planet VALUES (6, 'Saturn', 4503, 0, 0, 'The one with the rings', false, true, 1);
INSERT INTO public.planet VALUES (7, 'Uranus', 4503, 0, 0, 'The ice giant', false, true, 1);
INSERT INTO public.planet VALUES (8, 'Neptune', 4503, 0, 0, 'The gas planet', false, true, 1);
INSERT INTO public.planet VALUES (9, 'Pluto', 4500, 0, 0, 'The dwarf planet', false, true, 1);
INSERT INTO public.planet VALUES (10, 'Proxima b', 4850, 0, 0, 'Proxima centauri planet', false, true, 4);
INSERT INTO public.planet VALUES (11, 'Proxima c', 4850, 0, 0, 'Proxima centauri planet', false, true, 4);
INSERT INTO public.planet VALUES (12, 'Proxima d', 4850, 0, 0, 'Proxima centauri planet', false, true, 4);
INSERT INTO public.planet VALUES (13, 'Bb', 4850, 0, 0, 'Proxima centauri planet', false, true, 4);


--
-- Data for Name: star; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.star VALUES (1, 'Sun', 4500, 0, 0, 'Our sun', false, true, 1);
INSERT INTO public.star VALUES (2, 'Polaris', 70, 433, 0, 'North star', false, false, 1);
INSERT INTO public.star VALUES (3, 'Sirius', 242, 8611, 0, 'Brightest star', false, false, 1);
INSERT INTO public.star VALUES (4, 'Alpha Centauri', 485000, 4637, 0, 'Closest solar system', false, false, 1);
INSERT INTO public.star VALUES (5, 'Rigel', 864, 0, 8005, 'Super giant', false, false, 4);
INSERT INTO public.star VALUES (6, 'Vega', 455, 25, 0, 'Once the polar star', false, false, 1);


--
-- Name: asteroid_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.asteroid_id_seq', 3, true);


--
-- Name: galaxy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.galaxy_id_seq', 6, true);


--
-- Name: moon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.moon_id_seq', 20, true);


--
-- Name: planet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.planet_id_seq', 13, true);


--
-- Name: star_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.star_id_seq', 6, true);


--
-- Name: asteroid asteroid_id_unique; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.asteroid
    ADD CONSTRAINT asteroid_id_unique UNIQUE (asteroid_id);


--
-- Name: asteroid asteroid_pkey; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.asteroid
    ADD CONSTRAINT asteroid_pkey PRIMARY KEY (asteroid_id);


--
-- Name: galaxy galaxy_id_unqiue; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy
    ADD CONSTRAINT galaxy_id_unqiue UNIQUE (galaxy_id);


--
-- Name: galaxy galaxy_pkey; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy
    ADD CONSTRAINT galaxy_pkey PRIMARY KEY (galaxy_id);


--
-- Name: moon moon_id_unqiue; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon
    ADD CONSTRAINT moon_id_unqiue UNIQUE (moon_id);


--
-- Name: moon moon_pkey; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon
    ADD CONSTRAINT moon_pkey PRIMARY KEY (moon_id);


--
-- Name: planet planet_id_unqiue; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet
    ADD CONSTRAINT planet_id_unqiue UNIQUE (planet_id);


--
-- Name: planet planet_pkey; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet
    ADD CONSTRAINT planet_pkey PRIMARY KEY (planet_id);


--
-- Name: star star_id_unqiue; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star
    ADD CONSTRAINT star_id_unqiue UNIQUE (star_id);


--
-- Name: star star_pkey; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star
    ADD CONSTRAINT star_pkey PRIMARY KEY (star_id);


--
-- Name: moon moon_planet_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon
    ADD CONSTRAINT moon_planet_id_fkey FOREIGN KEY (planet_id) REFERENCES public.planet(planet_id);


--
-- Name: planet planet_star_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet
    ADD CONSTRAINT planet_star_id_fkey FOREIGN KEY (star_id) REFERENCES public.star(star_id);


--
-- Name: star star_galaxy_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star
    ADD CONSTRAINT star_galaxy_id_fkey FOREIGN KEY (galaxy_id) REFERENCES public.galaxy(galaxy_id);


--
-- PostgreSQL database dump complete
--

