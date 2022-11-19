USE PlaneswalkersPantry;

INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('LEA', 'Alpha', 1993);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('M15', 'Magic 2015', 2015);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('AKH', 'Amonkhet', 2017);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('RTR', 'Return to Ravnica', 2012);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('VOW', 'Innistrad: Crimson Vow', 2021);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('M10', 'Magic 2010', 2010);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('ODY', 'Odyssey', 2001);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('MOR', 'Morningtide', 2008);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('HOU', 'Hour of Devastation', 2017);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('DMU', 'Dominaria United', 2022);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('MID', 'Innistad: Midnight Hunt', 2021);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('MIR', 'Mirage', 1996);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('NEO', 'Kamigawa: Neon Dynasty', 2022);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('INV', 'Invasion', 2000);
INSERT INTO CARD_SET (SET_CODE, SET_NAME, RELEASE_YEAR) VALUES ('SNC', 'Streets of New Capenna', 2022);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (91, 'Plains', '', 'Tap: Add W.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (92, 'Island', '', 'Tap: Add U.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (93, 'Swamp', '', 'Tap: Add B.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (94, 'Mountain', '', 'Tap: Add R.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (95, 'Forest', '', 'Tap: Add G.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);


INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1, 'Black Lotus', '0', 'Tap, Sacrifice Black Lotus: Add three mana of any one color to your mana pool.',
        NULL, NULL, 'LEA', 'R', NULL, NULL, 'Artifact', 4);

VALUES (4, 'Accursed Spirit', '3B', 'Intimidate', NULL, NULL, 'M15', 'C', 3, 2, 'Creature - Spirit', 5);
INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (5, 'Act on Impulse', '2R', 'Exile the top three cards of your library. Until end of turn, you may play cards exiled this way. (If you cast a spell this way, you still pay its costs. You can play a land this way only if you have an available land play remaining.)', NULL, NULL, 'M15', 'U', NULL, NULL, 'Sorcery', 13);
INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (6, 'Aegis Angel', '4WW', 'Flying\n\nWhen Aegis Angel enters the battlefield, another target permanent gains indestructible for as long as you control Aegis Angel. (Effects that say "destroy" don''t destroy it. A creature with indestructible can''t be destroyed by damage.)',
        NULL, NULL, 'M15', 'R', 5, 5, 'Creature - Angel', 13);
INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (7, 'Chandra, Pyromaster', '2RR', '+1: Chandra, Pyromaster deals 1 damage to target player or planeswalker and 1 damage to up to one target creature that player or that planeswalker''s controller controls. That creature can''t block this turn.\n0: Exile the top card of your library. You may play it this turn.\n−7: Exile the top ten cards of your library. Choose an instant or sorcery card exiled this way and copy it three times. You may cast the copies without paying their mana costs.\n\nInitial Loyalty: 4', NULL, NULL, 'M15', 'M', NULL, NULL,
        'Planeswalker', 5);
INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (8, 'Chief Engineer', '1B', 'Artifact spells you cast have convoke. (Your creatures can help cast those spells. Each creature you tap while casting an artifact spell pays for 1 or one mana of that creature''s color.)', 'An eye for detail, a mind for numbers, a soul of clockwork.',
        NULL, 'M15', 'R', 1, 3, 'Creature - Vedalken Artificer', 3);
