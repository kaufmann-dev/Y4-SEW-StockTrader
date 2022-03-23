INSERT INTO stocktrader.stock (STOCK_ID, NAME) VALUES (3, 'HTL Krems GmbH');
INSERT INTO stocktrader.stock (STOCK_ID, NAME) VALUES (2, 'NetSolve');
INSERT INTO stocktrader.stock (STOCK_ID, NAME) VALUES (1, 'Pani GmbH');

INSERT INTO stocktrader.traders (TRADER_ID, FIRST_NAME, LAST_NAME) VALUES (1, 'Robert', 'Gakamek');
INSERT INTO stocktrader.traders (TRADER_ID, FIRST_NAME, LAST_NAME) VALUES (2, 'Florian', 'Marek');
INSERT INTO stocktrader.traders (TRADER_ID, FIRST_NAME, LAST_NAME) VALUES (3, 'Gakus', 'Scheiss');

INSERT INTO stocktrader.trader_has_stocks_jt (STOCK_ID, TRADER_ID, TRADED_AT, PRICE) VALUES (1, 1, '2022-03-02 14:52:48', 3);
INSERT INTO stocktrader.trader_has_stocks_jt (STOCK_ID, TRADER_ID, TRADED_AT, PRICE) VALUES (2, 2, '2022-03-02 14:52:52', 6969);
INSERT INTO stocktrader.trader_has_stocks_jt (STOCK_ID, TRADER_ID, TRADED_AT, PRICE) VALUES (3, 3, '2022-03-02 14:52:54', 420000);
