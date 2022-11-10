USE PlaneswalkersPantry;


INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1001, 'Hullbreaker Horror', '5UU', 'Flash\n\nThis spell can\'t be countered.\n\nWhenever you cast a spell, choose up to one —\n\nReturn target spell you don\'t control to its owner\'s hand.Return target nonland permanent to its owner\'s hand.', NULL, NULL, 'VOW', 'R', 7, 8, 'Creature - Kraken Horror', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1002, 'Essence Scatter', '1UU', 'Counter target creature spell.', '"Phyrexians pollute everything they touch, so the solution is simple: don\'t let them touch anything."\n\n—Teferi', NULL, 'M10', 'C', NULL, NULL, 'Instant', 50);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1003, 'Syncopate', 'XU', 'Counter target spell unless its controller pays X Variable Colorless. If that spell is countered this way, exile it instead of putting it into its owner\'s graveyard.', '"Fool! Can\'t you see the tide has turned against you?"', NULL, 'ODY', 'C', NULL, NULL, 'Instant', 50);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1004, 'Thirst for Discovery', '2U', 'Draw three cards. Then discard two cards unless you discard a basic land card.', 'I knew he had left the castle now, and thought to use the opportunity to explore more than I had dared to do as yet.', NULL, 'VOW', 'U', NULL, NULL, 'Instant', 25);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1005, 'Negate', '1U', 'Counter target noncreature spell.', '"It\'s frustrating, isn\'t it, to be so weak and ineffectual? Don\'t worry, you\'ll be compleat soon enough."\n\n—Rona', NULL, 'MOR', 'C', NULL, NULL, 'Instant', 50);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1006, 'Abrade', '1R', 'Choose one —\n\nAbrade deals 3 damage to target creature.\n\nDestroy target artifact.', 'The desert is a voracious beast, devouring both flesh and stone.', NULL, 'HOU', 'C', NULL, NULL, 'Instant', 50);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1007, 'Fires of Victory', '1R', 'Kicker 2B (You may pay an additional 2B as you cast this spell.)\n\nIf this spell was kicked, draw a card. Fires of Victory deals damage to target creature or planeswalker equal to the number of cards in your hand.', 'The drums and horns were expected, but the goblin dance was a pleasant surprise.', NULL, 'DMU', 'U', NULL, NULL, 'Instant', 25);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1008, 'Flame-Blessed Bolt', 'R', 'Flame-Blessed Bolt deals 2 damage to target creature or planeswalker. If that creature or planeswalker would die this turn, exile it instead.', '"I noticed you were short on party favors, so I brought my own."\n\n—Higa, slayer-captain of Gatstaf', NULL, 'VOW', 'C', NULL, NULL, 'Instant', 50);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1009, 'Memory Deluge', '2UU', 'Look at the top X cards of your library, where X is the amount of mana spent to cast this spell. Put two of them into your hand and the rest on the bottom of your library in a random order.\n\nFlashback 5BB (You may cast this card from your graveyard for its flashback cost. Then exile it.)', NULL, NULL, 'MID', 'R', NULL, NULL, 'Instant', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1010, 'Dissipate', '1UU', 'Flame-Blessed Bolt deals 2 damage to target creature or planeswalker. If that creature or planeswalker would die this turn, exile it instead.', '"Morning light, morning light, Chase away the fears of night."\n\n—Gavony children\'s rhyme', NULL, 'MIR', 'U', NULL, NULL, 'Instant', 25);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1011, 'Silver Scrutiny', 'XUU', 'You may cast Silver Scrutiny as though it had flash if X is 3 or less.\n\nDraw X cards.', NULL, NULL, 'DMU', 'R', NULL, NULL, 'Sorcery', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1012, 'Burn Down the House', '3RR', 'Choose one —\n\nBurn Down the House deals 5 damage to each creature and each planeswalker.\n\nCreate three 1/1 red Devil creature tokens with "When this creature dies, it deals 1 damage to any target." They gain haste until end of turn.', NULL, NULL, 'MID', 'R', NULL, NULL, 'Sorcery', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1013, 'Sokenzan, Crucible of Defiance', '', 'Tap: Add Red.\n\nChannel — 3R, Discard Sokenzan, Crucible of Defiance: Create two 1/1 colorless Spirit creature tokens. They gain haste until end of turn. This ability costs 1 less to activate for each legendary creature you control.', NULL, NULL, 'NEO', 'R', NULL, NULL, 'Legendary Land', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1014, 'Otawara, Soaring City', '', 'Tap: Add B.\n\nChannel — 3B, Discard Otawara, Soaring City: Return target artifact, creature, enchantment, or planeswalker to its owner\'s hand. This ability costs 1 less to activate for each legendary creature you control.', NULL, NULL, 'NEO', 'R', NULL, NULL, 'Legendary Land', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1015, 'Stormcarved Coast', '', 'Stormcarved Coast enters the battlefield tapped unless you control two or more other lands.\n\nTap: Add B or R.', NULL, NULL, 'VOW', 'R', NULL, NULL, 'Land', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1016, 'Shivan Reef', '', 'Tap: Add Colorless.\n\nTap: Add B or R. Shivan Reef deals 1 damage to you.', NULL, NULL, 'INV', 'R', NULL, NULL, 'Land', 5);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1017, 'Mountain', '', 'Tap: Add R.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1018, 'Island', '', 'Tap: Add B.', NULL, NULL, 'LEA', 'C', NULL, NULL, 'Land', 100);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (1019, 'Unlicensed Hearse', '2', 'Tap: Exile up to two target cards from a single graveyard.\n\nUnlicensed Hearse\'s power and toughness are each equal to the number of cards exiled with it.\n\nCrew 2', NULL, NULL, 'SNC', 'R', '*', '*', 'Artifact - Vehicle', 5);

-- The below cards are on the deck's sideboard, which is not yet implemented in Planeswalker's Pantry.

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (20, 'Spell Pierce', 'U', 'Counter target noncreature spell unless its controller pays 2.', '"If you make me spill my drink, you\'re buying me a new one."', NULL, '###', 'C', NULL, NULL, 'Instant', 50);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (21, 'Reckoner Bankbuster', '2', 'Reckoner Bankbuster enters the battlefield with three charge counters on it.\n\n2, Tap, Remove a charge counter from Reckoner Bankbuster: Draw a card. Then if there are no charge counters on Reckoner Bankbuster, create a Treasure token and a 1/1 colorless Pilot creature token with "This creature crews Vehicles as though its power were 2 greater."\n\nCrew 3', NULL, NULL, '###', 'R', 4, 4, 'Artifact - Vehicle', 5);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (22, 'Negate', '1U', 'Counter target noncreature spell.','"It\'s frustrating, isn\'t it, to be so weak and ineffectual? Don\'t worry, you\'ll be compleat soon enough."\n\n—Rona' , NULL, '###', 'C', NULL, NULL, 'Instant', 50);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (23, 'Fires of Victory', '1R', 'Kicker 2B (You may pay an additional 2B as you cast this spell.)\n\nIf this spell was kicked, draw a card. Fires of Victory deals damage to target creature or planeswalker equal to the number of cards in your hand.', 'The drums and horns were expected, but the goblin dance was a pleasant surprise.', NULL, '###', 'U', NULL, NULL, 'Instant', 25);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (24, 'Essence Scatter', '1UU', 'Counter target creature spell.', '"Phyrexians pollute everything they touch, so the solution is simple: don\'t let them touch anything."\n\n—Teferi', NULL, '###', 'C', NULL, NULL, 'Instant', 50);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (25, 'Burn Down the House', '3RR', 'Choose one —\n\nBurn Down the House deals 5 damage to each creature and each planeswalker.\n\nCreate three 1/1 red Devil creature tokens with "When this creature dies, it deals 1 damage to any target." They gain haste until end of turn.', NULL, NULL, '###', 'R', NULL, NULL, 'Sorcery', 5);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (26, 'Disdainful Stroke', '1U', 'Counter target spell with mana value 4 or greater.', '"I\'ve known for a year that you would cast this exact spell, at this exact spot, at this exact time."\n\n—Raffine', NULL, '###', 'C', NULL, NULL, 'Instant', 50);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (27, 'Smoldering Egg', '1R', 'Defender\n\nWhenever you cast an instant or sorcery spell, put a number of ember counters on Smoldering Egg equal to the amount of mana spent to cast that spell. Then if Smoldering Egg has seven or more ember counters on it, remove them and transform Smoldering Egg.', NULL, NULL, '###', 'R', NULL, NULL, 'Creature - Dragon Egg', 5);

-- INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
-- VALUES (28, 'Fable of the Mirror-Breaker', '2R', '(As this Saga enters and after your draw step, add a lore counter.)\n\nI — Create a 2/2 red Goblin Shaman creature token with "Whenever this creature attacks, create a Treasure token."\n\nII — You may discard up to two cards. If you do, draw that many cards.\n\nIII — Exile this Saga, then return it to the battlefield transformed under your control.', NULL, NULL, '###', 'R', NULL, NULL, 'Enchantment - Saga', 5);
