USE PlaneswalkersPantry;

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED) VALUES (20001, 'Llanowar Greenwidow', '2G', 'Reach, trample.\n\nDomain - 7G: Return Llanowar Greenwidow from your graveyard to the battlefield tapped. It gains "If this permanent would leave the battlefield, exile it instead of putting it anywhere else." This ability costs 1 less to activate for each basic land type among lands you control.', NULL, NULL, '###', 'R', 4, 3, 'Creature - Spider', 17);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20002, 'Sphinx of Clear Skies', '3BB', 'Flying, ward 2\n\nDomain - Whenever Sphinx of Clear Skies deals combat damage to a player, reveal the top X cards of your library, where X is the number of basic land types among lands you control. An opponent separates those cards into two piles. Put one pile into your hand and other into your graveyard. (Piles can be empty.)', NULL, NULL, '###', 'M', 5, 5, 'Creature - Sphinx', 5);

-- Note: This is a double-faced card. There are many double-faced cards in Magic: The Gathering. However,
-- implementing this feature would add significant time to the implementation. Therefore, I am only listing
-- the "front" (playable) side in this database.
INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20003, 'The Kami War', '1WUBRG', '(As this Saga enters play and after your draw step, add a lore counter.)\n\nI - Exile target nonland permanent an opponent controls\n\nII - Return up to one other target nonland permanent to its owner\'s hand. Then each opponent discards a card.\n\n(This is a double-faced card.)', NULL, NULL, 'NEO', 'M', NULL, NULL, 'Enchantment - Saga', 2);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20004, 'Jodah\'s Codex', '5', 'Domain - 5, Tap: Draw a card. This ability costs 1 less to activate for each basic land among lands you control', 'If you remember nothing else of our world\'s history, remember this: Phyrexians can be defeated.\n\n- Jodah', NULL, '###', 'U', NULL, NULL, 'Artifact', 2);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20005, 'The Celestus', '3', 'If it\'s neither day nor night, it becomes day as The Celestus enters the battlefield.\n\nTap: Add one mana of any color.\n\n3, Tap: If it\'s night, it becomes day. Otherwise, it becomes night. Activate only as a sorcery.\n\nWhenever day becomes night or night becomes day, you gain 1 life. You may draw a card. If you do, discard a card.', NULL, NULL, '###', 'R', NULL, NULL, 'Legendary Artifact', 1);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20006, 'Shadow Prophecy', '2B', 'Domain - Look at the top X cards of your library, where X is the number of basic land types among lands you control. Put up to two of them into your hand and the rest into your graveyard.You lose 2 life.', 'Lord Windgrace, grant me wisdom.', NULL, '###', 'C', NULL, NULL, 'Instant', 4);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20007, 'Cut Down', 'B', 'Destroy target creature with total power and toughness 5 or less.', 'There can be no mercy, no half measures. When facing Phyrexians, it\'s kill swiftly or die.', NULL, '###', 'U', NULL, NULL, 'Instant', 17);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20008, 'Farewell', '4WW', 'Choose one or more-\n* Exile all artifacts\n* Exile all creatures.\n* Exile all enchantments.\n* Exile all graveyards.', NULL, NULL, 'NEO', 'R', NULL, NULL, 'Sorcery', 3);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20009, 'Depopulate', '2WW', 'Each player who controls a multicolored creature draws a card. Then destroy all creatures.', 'No screams rang out. No blood stained the streets. In a instant, the bustling metropolis simple fell silent.', NULL, '###', 'R', NULL, NULL, 'Sorcery', 3);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20010, 'Slimefoot\'s Survey', '4G', 'Domain - Search your library for up to two land cards that each have a basic land type, put them onto the battlefield tapped, then shuffle. Look at the top X cards of your library, where X is the number of basic land types among lands you control. Put up to one of them on top of your library and the rest on the bottomk of your library in a random order.', NULL, NULL, '###', 'U', NULL, NULL, 'Sorcery', 17);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20011, 'Herd Migration', '6G', 'Domain - Create a 3/3 Beast creature token for each basic land type among lands you control.\n\n1G, Discard Herd Migration: Search your library for a basic land card, reveal it, put it into your hand, then shuffle.', NULL, NULL, '###', 'R', NULL, NULL, 'Sorcery', 9);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20012, 'The Weatherseed Treaty', '2G', 'Read ahead (Choose a chapter and start with that many lore counters. Add one after your draw step. Skipped chapters don\'t trigger. Sacrifice after III.)\n\nI - Search your library for a basic land card, put it onto the battlefield tapped, then shuffle\n\nII - Create a 1/1 green Saproling token.\n\nIII - Domain - Target creature you control gets +X/+X and gains trample until end of term, where X is the number of basic land types among lands you control.', NULL, NULL, '###', 'U', NULL, NULL, 'Enchantment - Saga', 7);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20013, 'Leyline Binding', '5W', 'Flash\n\nDomain - This spell costs 1 less to cast for each basic land type among lands you control.\n\nWhen Leyline Binding enters the battlefield, exile target nonland permanent an opponent controls until Leyline Binding leaves the battlefield.', NULL, NULL, '###', 'R', NULL, NULL, 'Enchantment', 18);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20014, 'Xander\'s Lounge', '', '(Tap: Add U, B, or R.)\n\nXander\'s Lounge enters the battlefield tapped.\n\nCycling 3 (3, discard this card: Draw a card.)', 'Maestros agents can lie low in high style at the opulent Shadow Hotel.', NULL, '###', 'R', NULL, NULL, 'Land - Island Swamp Mountain', 91);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20015, 'Ziatora\'s Proving Ground', '', '(Tap: Add B, R, or G.)\n\nZiatora\'s Proving Ground Battlefield enters the battlefield tapped.\n\nCycling 3 (3, discard this card: Draw a card.)', 'Restless Riveteers can always find a sparring partner in the sprawling Treza warehouse.', NULL, '###', 'R', NULL, NULL, 'Land - Swamp Mountain Forest', 29);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20016, 'Spara\'s Headquarters', '', '(Tap: Add G, W, or U.)\n\nSpera\'s Headquarters enters the battlefield tapped.\n\nCycling 3 (3, discard this card: Draw a card.)', 'To most, the Nido Sanctuary is an office complex. To the Brokers, it\'s a vault of secrets', NULL, '###', 'R', NULL, NULL, 'Land - Forest Plains Island', 12);

INSERT INTO CARD (CARD_NUMBER, CARD_TITLE, MANA_COST, RULES_TEXT, FLAVOR_TEXT, CARD_IMAGE, SET_CODE, RARITY_CODE, POWER, TOUGHNESS, TYPE_LINE, NUMBER_OWNED)
VALUES (20017, 'Jetmir\'s Garden', '', '(Tap: Add R, G, or W.)\n\nJetmir\'s Garden enters the battlefield tapped.\n\nCycling 3 (3, discard this card: Draw a card.)', 'The portable Cabareth grounds offer food, and the pefect place to shake off a tail.', NULL, '###', 'R', NULL, NULL, 'Land - Mountain Forest Plains', 7);


INSERT INTO DECK (DECK_NUMBER, DECK_TITLE, DECK_COLORS) VALUES (102, 'DomainDMU Deck', 'WUBRG');
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20001, 2); -- Llanowar Greenwidow
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20002, 2); -- Sphinx of Clear Skies
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20003, 4); -- The Kami War
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20004, 2); -- Jodah's Codex
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20005, 2); -- The Celestus
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20006, 1); -- Shadow Prophecy
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20007, 3); -- Cut Down
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20008, 2); -- Farewell
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20009, 2); -- Depopulate
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20010, 2); -- Slimefoot's Survey
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20011, 4); -- Herd Migration
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20012, 4); -- The Weatherseed Treaty
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20013, 4); -- Leyline Binding
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20014, 2); -- Xander's Lounge
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20016, 2); -- Spara's Headquarters
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20017, 2); -- Jetmir's Garden
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20015, 4); -- Raffine's Tower
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 20015, 4); -- Ziatora's Proving Ground
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 95, 1); -- Mountain
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 91, 2); -- Plains
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 93, 3); -- Swamp
INSERT INTO CARD_IN_DECK (DECK_NUMBER, CARD_NUMBER, COUNT) VALUES (102, 95, 4); -- Forest

-- CARD_NUMBER needs to be a unique integer. I know of no way to get MySQL to generate these for us.
-- CARD_TITLE is the bolded text in the top-left of each card.
-- MANA_COST is the symbols from the top-right of the card. Enter numbers and "X" as themselves.
--   For the colored symbols, use the following letters instead:
--     small white sun: W
--     blue raindrop: U
--     black skull: B
--     red wave: R
--     green tree: G
--     small gray diamond: C
--   If you see any other symbols in this area, please message me and I will convert them for you.
-- RULES_TEXT: This is the text in the bottom-middle area of the card. Use your best judgment to
--   convert the formatting; remember that this field is plain text. You will need to place the
--   entire text all on one line, unfortunately (if I try to split it, I get syntax errors). I
--   highly recommend turning on line-wrapping in your editor of choice. If there is a paragraph
--   break on the card, type '\n\n'. If there is a horizontal line within this box, this is the
--   text on the top. If there is only italicized text, put ''. If you see any numbers in round
--   circles, type them as-is. If you see small circular colored symbols, use the letters described
--   above under MANA_COST. If you see a small circular arrow, type the word "tap".
-- FLAVOR_TEXT: If there is a horizontal line in the bottom-middle area, this is the text on the
--   bottom. It will always be italicized. If there is only italic text, put it here. If there
--   is no horizontal line, put NULL.
-- CARD_IMAGE: Always put NULL.
-- SET_CODE: Put '###' here and I will fix this column up later. This is the most time-consuming
--   piece of information to extract from a card.
-- RARITY_CODE: Look at the small symbol to right-hand side of the bar in the middle. If this
--   symbol is black, put C. If it is silver, put U. If it is gold, put R. If it is a kind of
--   metallic red color, put M. If there is no symbol there at all, put C.
-- POWER: There may be two numbers set apart at the bottom-right corner of the card, separated
--   by a slash. This is the number on the left. If there are no numbers, put NULL.
-- TOUGHNESS: This is the number on the right of the slash. If there are no numbers, put NULL.
-- TYPE_LINE: On the bar at the middle of the card, there should be some text on the left.
--   Copy this line of text verbatim. There should always be text here.
-- NUMBER_OWNED: Pick a random integer. Put it here.
