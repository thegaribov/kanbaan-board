--
-- PostgreSQL database dump
--

-- Dumped from database version 13.5
-- Dumped by pg_dump version 13.5

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

--
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: kanban-user
--



--
-- Data for Name: AspNetRoleClaims; Type: TABLE DATA; Schema: public; Owner: kanban-user
--



--
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: kanban-user
--

INSERT INTO public."AspNetUsers" ("Id", "UpdatedAt", "CreatedAt", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "FullName") VALUES ('ea621d46-aae4-4a4b-854b-b79dda5dd10a', '0001-01-01 00:00:00', '2022-02-17 10:26:03.620548', 'qaribovmahmud@gmail.com', 'QARIBOVMAHMUD@GMAIL.COM', 'qaribovmahmud@gmail.com', 'QARIBOVMAHMUD@GMAIL.COM', false, 'AQAAAAEAACcQAAAAEAEgyXicMRw2037M9rESkv9f8srnYj8kf8bRwo2wrCPJn9Du09HTOgGubNj257O6/Q==', 'HKOV2ESBP2BJJWYAALV4LSN36FXQ2J3K', 'b4748056-bd02-4de1-b857-f4c7fccd2b5f', NULL, false, false, NULL, true, 0, 'Mahmood Garibov');
INSERT INTO public."AspNetUsers" ("Id", "UpdatedAt", "CreatedAt", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "FullName") VALUES ('1dd94e73-fbb6-4662-9590-80a3c970d8fe', '0001-01-01 00:00:00', '2022-02-17 10:31:28.223595', 'mahmood.garibov@gmail.com', 'MAHMOOD.GARIBOV@GMAIL.COM', 'mahmood.garibov@gmail.com', 'MAHMOOD.GARIBOV@GMAIL.COM', false, 'AQAAAAEAACcQAAAAEHCyRcA78EaJQgDTPdEuPZlS6idElZWikwwMYtSi+uioHjEz1uTSQ9UJffA5E005mg==', 'F4SYWQW4XNCWZA3DMDZY5AZLOQYGEUMQ', 'e1ad7d8f-0ab6-47b2-b71e-edfe8a5125e6', NULL, false, false, NULL, true, 0, 'Elchin Qaribov');
INSERT INTO public."AspNetUsers" ("Id", "UpdatedAt", "CreatedAt", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "FullName") VALUES ('6b83c1a5-f39e-40fb-8e06-cbe48393925b', '0001-01-01 00:00:00', '2022-02-17 10:34:40.226777', 'john@garibov.com', 'JOHN@GARIBOV.COM', 'john@garibov.com', 'JOHN@GARIBOV.COM', false, 'AQAAAAEAACcQAAAAEMMFtpFkHfL4FvH6h5MkZie1ItDhq0i0CHMvyYBMiNoYuRGb6Nv6oYQmjddPZlaVYg==', 'THQHUZQXZ3QVCJD2FQOLYHCRWU4AYUEV', 'ef57c924-a08b-4d66-b620-8b81fba8ad4e', NULL, false, false, NULL, true, 0, 'John Kennedy');
INSERT INTO public."AspNetUsers" ("Id", "UpdatedAt", "CreatedAt", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "FullName") VALUES ('c00ddae1-0380-41bc-9825-f89e1ec21314', '0001-01-01 00:00:00', '2022-02-17 10:35:18.402554', 'alise@garibov.com', 'ALISE@GARIBOV.COM', 'alise@garibov.com', 'ALISE@GARIBOV.COM', false, 'AQAAAAEAACcQAAAAEB9aPMXkhhrKMiwcGyVoWkOqraYubZeCb3QhZbPHiiIcdUcvxnoFzqNBKKd/IJFixg==', 'LCUR2EPSJBFUOJOAV6QUKLWRHXSPNB7P', '0c192326-90cd-4a12-b79e-11b431368b9b', NULL, false, false, NULL, true, 0, 'Alise Green');
INSERT INTO public."AspNetUsers" ("Id", "UpdatedAt", "CreatedAt", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "FullName") VALUES ('2c2eee2e-d63c-4983-a9bf-5fa34be4cc18', '0001-01-01 00:00:00', '2022-02-17 10:36:59.272967', 'alberto@gmail.com', 'ALBERTO@GMAIL.COM', 'alberto@gmail.com', 'ALBERTO@GMAIL.COM', false, 'AQAAAAEAACcQAAAAENJ7OgZIEhrpoz2HYC1eYeF1cn/+UYUmuK82OOgbQOCY/aOR7gMLcbkKOv+h86AegQ==', 'VQ7EUHZB2PQJID3UYO7LRRNTYSQWQNDP', '12fe728f-d08a-4505-b5df-46bf25a23f3e', NULL, false, false, NULL, true, 0, 'Alberto Washington');


--
-- Data for Name: AspNetUserClaims; Type: TABLE DATA; Schema: public; Owner: kanban-user
--



--
-- Data for Name: AspNetUserLogins; Type: TABLE DATA; Schema: public; Owner: kanban-user
--



--
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: kanban-user
--



--
-- Data for Name: AspNetUserTokens; Type: TABLE DATA; Schema: public; Owner: kanban-user
--


--
-- Data for Name: Organisations; Type: TABLE DATA; Schema: public; Owner: kanban-user
--

INSERT INTO public."Organisations" ("Id", "Name", "PhoneNumber", "Address", "UpdatedAt", "CreatedAt") VALUES (1, 'Nokia', '0503144847', 'Azerbaijan, Baku, Xetai Cavanshir streen', '0001-01-01 00:00:00', '2022-02-17 10:24:58.796166');
INSERT INTO public."Organisations" ("Id", "Name", "PhoneNumber", "Address", "UpdatedAt", "CreatedAt") VALUES (2, 'Nokia', '0503144847', 'Azerbaijan, Baku, Xetai Cavanshir streen', '0001-01-01 00:00:00', '2022-02-17 10:26:03.623428');


--
-- Data for Name: Tickets; Type: TABLE DATA; Schema: public; Owner: kanban-user
--

INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (3, 'Bug fixing ', 'Threre are bugs in REST APIs', '2022-02-19 00:00:00', 1, '0001-01-01 00:00:00', '2022-02-17 10:38:30.866782', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (1, 'API integration', 'Do something', '2022-02-18 00:00:00', 2, '2022-02-17 10:38:40.838756', '2022-02-17 10:30:11.63732', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (2, 'Google API integration', 'Lorem Ipsum is simply dummy', '2022-02-25 00:00:00', 1, '2022-02-17 10:38:55.317059', '2022-02-17 10:37:47.388783', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (4, 'Payment integration', 'Lorem Ipsum is simply dummy', '2022-02-18 00:00:00', 3, '0001-01-01 00:00:00', '2022-02-17 10:39:31.068139', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (5, 'Docker setup', 'Lorem Ipsum is simply dummy', '2022-02-19 00:00:00', 4, '0001-01-01 00:00:00', '2022-02-17 10:40:08.245869', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (6, 'SMTP problem ', 'Lorem Ipsum is simply dummy', '2022-02-26 00:00:00', 1, '0001-01-01 00:00:00', '2022-02-17 10:40:29.097098', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (7, 'CI/CD pipeline ', 'Lorem Ipsum is simply dummy', '2022-02-26 00:00:00', 4, '2022-02-17 10:46:41.101086', '2022-02-17 10:45:27.320382', 2);
INSERT INTO public."Tickets" ("Id", "Title", "Description", "Deadline", "Status", "UpdatedAt", "CreatedAt", "OrganisationId") VALUES (8, 'CI/CD bugfix', 'Lorem Ipsum is simply dummy', '2022-02-18 00:00:00', 4, '0001-01-01 00:00:00', '2022-02-17 10:47:11.386876', 2);


--
-- Data for Name: UserOrganisations; Type: TABLE DATA; Schema: public; Owner: kanban-user
--

INSERT INTO public."UserOrganisations" ("UserId", "OrganisationId", "Role", "UpdatedAt", "CreatedAt") VALUES ('ea621d46-aae4-4a4b-854b-b79dda5dd10a', 2, 0, '0001-01-01 00:00:00', '2022-02-17 10:26:03.627205');
INSERT INTO public."UserOrganisations" ("UserId", "OrganisationId", "Role", "UpdatedAt", "CreatedAt") VALUES ('1dd94e73-fbb6-4662-9590-80a3c970d8fe', 2, 1, '0001-01-01 00:00:00', '2022-02-17 10:31:28.227722');
INSERT INTO public."UserOrganisations" ("UserId", "OrganisationId", "Role", "UpdatedAt", "CreatedAt") VALUES ('6b83c1a5-f39e-40fb-8e06-cbe48393925b', 2, 1, '0001-01-01 00:00:00', '2022-02-17 10:34:40.231804');
INSERT INTO public."UserOrganisations" ("UserId", "OrganisationId", "Role", "UpdatedAt", "CreatedAt") VALUES ('c00ddae1-0380-41bc-9825-f89e1ec21314', 2, 1, '0001-01-01 00:00:00', '2022-02-17 10:35:18.407447');
INSERT INTO public."UserOrganisations" ("UserId", "OrganisationId", "Role", "UpdatedAt", "CreatedAt") VALUES ('2c2eee2e-d63c-4983-a9bf-5fa34be4cc18', 2, 1, '0001-01-01 00:00:00', '2022-02-17 10:36:59.276995');


--
-- Data for Name: UserTickets; Type: TABLE DATA; Schema: public; Owner: kanban-user
--

INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (1, 'ea621d46-aae4-4a4b-854b-b79dda5dd10a', '0001-01-01 00:00:00', '2022-02-17 10:38:40.847878');
INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (1, '1dd94e73-fbb6-4662-9590-80a3c970d8fe', '0001-01-01 00:00:00', '2022-02-17 10:38:40.856439');
INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (4, 'c00ddae1-0380-41bc-9825-f89e1ec21314', '0001-01-01 00:00:00', '2022-02-17 10:39:31.078622');
INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (5, 'ea621d46-aae4-4a4b-854b-b79dda5dd10a', '0001-01-01 00:00:00', '2022-02-17 10:40:08.254181');
INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (5, 'c00ddae1-0380-41bc-9825-f89e1ec21314', '0001-01-01 00:00:00', '2022-02-17 10:40:08.258399');
INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (7, 'c00ddae1-0380-41bc-9825-f89e1ec21314', '0001-01-01 00:00:00', '2022-02-17 10:46:41.133292');
INSERT INTO public."UserTickets" ("TicketId", "UserId", "UpdatedAt", "CreatedAt") VALUES (8, '6b83c1a5-f39e-40fb-8e06-cbe48393925b', '0001-01-01 00:00:00', '2022-02-17 10:47:11.397748');


--
-- Data for Name: spatial_ref_sys; Type: TABLE DATA; Schema: public; Owner: kanban-user
--



--
-- Data for Name: geocode_settings; Type: TABLE DATA; Schema: tiger; Owner: kanban-user
--



--
-- Data for Name: pagc_gaz; Type: TABLE DATA; Schema: tiger; Owner: kanban-user
--



--
-- Data for Name: pagc_lex; Type: TABLE DATA; Schema: tiger; Owner: kanban-user
--



--
-- Data for Name: pagc_rules; Type: TABLE DATA; Schema: tiger; Owner: kanban-user
--



--
-- Data for Name: topology; Type: TABLE DATA; Schema: topology; Owner: kanban-user
--



--
-- Data for Name: layer; Type: TABLE DATA; Schema: topology; Owner: kanban-user
--



--
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


--
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);


--
-- Name: DataProtectionKeys_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."DataProtectionKeys_Id_seq"', 1, true);


--
-- Name: Notifications_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."Notifications_Id_seq"', 13, true);


--
-- Name: NotifyEvents_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."NotifyEvents_Id_seq"', 1, true);


--
-- Name: Organisations_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."Organisations_Id_seq"', 2, true);


--
-- Name: Tickets_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: kanban-user
--

SELECT pg_catalog.setval('public."Tickets_Id_seq"', 8, true);


--
-- PostgreSQL database dump complete
--

