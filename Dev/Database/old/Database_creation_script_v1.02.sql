
-- =============================================================================
-- Script de création de base de données.
-- On crée les tables avec un script car l'outil SQLite Browser ne permet pas
-- de créer les tables avec des clés étrangères (Foreign Key)
-- 
-- Historique
-- v1.00 - pas de script, fichier créé dans SqLite Browser
-- v1.01 - pas de script, fichier créé dans SqLite Browser
-- v1.02 - version initiale de script, avec seulement les tables CTEC et le lot 256001
-- =============================================================================

-- =============================================================================
-- On efface toutes les tables en ordre de clé étrangèeres
-- =============================================================================
DROP TABLE item_payment;
DROP TABLE item_statement;
DROP TABLE matched_payment;
DROP TABLE capture_batch;
DROP TABLE statement_definition;
DROP TABLE capture_site_definition;

-- =============================================================================
-- On réinsèere les tables
-- =============================================================================
CREATE TABLE 'capture_site_definition' (
  'site_id' INTEGER,
  'description' TEXT,
  PRIMARY KEY(site_id)
);

CREATE TABLE 'statement_definition' (
  'statement_id' INTEGER,
  'home_site' INTEGER,
  'description' TEXT,
  PRIMARY KEY(statement_id),
  FOREIGN KEY(home_site) REFERENCES capture_site_definition(site_id)
);

CREATE TABLE 'capture_batch' (
  'batch_seq' INTEGER,
  'capture_date' TEXT NOT NULL, -- string YYYYMMDD dans la BD originale
  'capture_id' INTEGER,
  'capture_type_item' TEXT NOT NULL,
  'client_batch_ref_number' TEXT,
  'custom_batch_number' INTEGER,
  'exception_batch' INTEGER,
  'statement_id' INTEGER NOT NULL,
  'reprocessing_batch' INTEGER,
  PRIMARY KEY(batch_seq),
  FOREIGN KEY(statement_id) REFERENCES statement_definition(statement_id)
);

CREATE TABLE 'matched_payment' (
  'batch_seq' INTEGER,
  'matched_payment_seq' INTEGER,
  'matched_payment_status' TEXT,
  PRIMARY KEY(batch_seq, matched_payment_seq),
  FOREIGN KEY(batch_seq) REFERENCES capture_batch(batch_seq)
);

CREATE TABLE 'item_payment' (
  'batch_seq' INTEGER,
  'item_ref' INTEGER,
  'payment_amount' REAL,
  'image_file_front' TEXT,
  'image_file_rear' TEXT,
  'item_source' TEXT,
  'item_status' TEXT,
  'matched_payment_seq' INTEGER NOT NULL,
  'text_1' TEXT,
  'bank_account' TEXT,
  'check_no' TEXT,
  PRIMARY KEY(batch_seq, item_ref),
  FOREIGN KEY(batch_seq, matched_payment_seq)
    REFERENCES matched_payment(batch_seq, matched_payment_seq)
);

CREATE TABLE 'item_statement' (
  'batch_seq' INTEGER,
  'item_ref' INTEGER,
  'amount_due' REAL,
  'amount_paid' REAL,
  'chadd_status' INTEGER,
  'image_file_front' TEXT,
  'image_file_rear' TEXT,
  'item_source' TEXT,
  'item_status' TEXT,
  'matched_payment_seq' INTEGER NOT NULL,
  'text_1' TEXT,
  'transaction_reference' TEXT,
  PRIMARY KEY(batch_seq, item_ref),
  FOREIGN KEY(batch_seq, matched_payment_seq)
    REFERENCES matched_payment(batch_seq, matched_payment_seq)
);

-- =============================================================================
-- Insertion de données - CAPTURE_SITE_DEFINITION
-- =============================================================================

INSERT INTO capture_site_definition(site_id, description) VALUES (0, 'Addison, IL');
INSERT INTO capture_site_definition(site_id, description) VALUES (1, 'Irving, TX');
INSERT INTO capture_site_definition(site_id, description) VALUES (3, 'Charlotte, NC');

-- =============================================================================
-- Insertion de données - STATEMENT_DEFINITION
-- =============================================================================

INSERT INTO statement_definition(statement_id, home_site, description) VALUES(1319, 3, 'CTLK');
INSERT INTO statement_definition(statement_id, home_site, description) VALUES(4331, 0, 'ASAWDP');
INSERT INTO statement_definition(statement_id, home_site, description) VALUES(4366, 0, 'ASAWDH');

-- =============================================================================
-- Insertion de données - CAPTURE_BATCH
-- =============================================================================

INSERT INTO capture_batch(batch_seq, capture_date, capture_id, capture_type_item,
  client_batch_ref_number, custom_batch_number, exception_batch, statement_id, 
  reprocessing_batch)
  VALUES
  (
    256001,     --batch_seq
    '20160609', --capture_date
    11111111,   --capture_id
    2,          --capture_type_item
    '123456',   --client_batch_ref_number
    5000,       --custom_batch_number
    null,       --exception_batch
    1319,       --statement_id
    null        --reprocessing_batc
  );

-- =============================================================================
-- Insertion de données - MATCHED_PAYMENT
--                        FK sur capture_batch
-- =============================================================================

-- possibilités de matched_payment_status (voir dictionnaire BD):
-- 1 Automatically Matched
-- 2 Manually Matched
-- 3 Rejected Items
-- 4 Rejected Envelope
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256001, 1, 1);
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256001, 2, 4);
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256001, 3, 2);
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256001, 4, 1);

-- =============================================================================
-- Insertion de données - ITEM_STATEMENT
--                        FK sur matched_payment
-- =============================================================================

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  image_file_front, image_file_rear, item_source, item_status, matched_payment_seq,
  text_1, transaction_reference)
  VALUES
  (
    256001,    --batch_seq
    10,        --item_ref
    60.15,     --amount_due
    60.15,     --amount_paid
    1,         --chadd_status
    '1',       --image_file_front
    '2',       --image_file_rear
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    null,      --text_1
    'GALF1003' --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  image_file_front, image_file_rear, item_source, item_status, matched_payment_seq,
  text_1, transaction_reference)
  VALUES
  (
    256001, --batch_seq
    30,     --item_ref
    30.00,  --amount_due
    12.25,  --amount_paid
    null,   --chadd_status
    '3',    --image_file_front
    '4',    --image_file_rear
    1,      --item_source
    2,      --item_status
    2,      --matched_payment_seq
    null,   --text_1
    null    --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  image_file_front, image_file_rear, item_source, item_status, matched_payment_seq,
  text_1, transaction_reference)
  VALUES
  (
    256001,    --batch_seq
    50,        --item_ref
    10.00,     --amount_due
    55.55,     --amount_paid
    0,         --chadd_status
    '5',       --image_file_front
    '6',       --image_file_rear
    1,         --item_source
    1,         --item_status
    3,         --matched_payment_seq
    null,      --text_1
    '52589729' --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  image_file_front, image_file_rear, item_source, item_status, matched_payment_seq,
  text_1, transaction_reference)
  VALUES
  (
    256001, --batch_seq
    60,     --item_ref
    null,   --amount_due
    null,   --amount_paid
    null,   --chadd_status
    '7',    --image_file_front
    '8',    --image_file_rear
    1,      --item_source
    7,      --item_status
    3,      --matched_payment_seq
    null,   --text_1
    null    --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  image_file_front, image_file_rear, item_source, item_status, matched_payment_seq,
  text_1, transaction_reference)
  VALUES
  (
    256001,     --batch_seq
    80,         --item_ref
    100.0,      --amount_due
    100.0,      --amount_paid
    0,          --chadd_status
    '9',        --image_file_front
    '10',       --image_file_rear
    1,          --item_source
    1,          --item_status
    4,          --matched_payment_seq
    null,       --text_1
    'GODFP3QBC' --transaction_reference
  );

-- =============================================================================
-- Insertion de données - ITEM_PAYMENT
--                        FK sur matched_payment
-- =============================================================================

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, image_file_front, 
  image_file_rear, item_source, item_status, matched_payment_seq, text_1, 
  bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    20,        --item_ref
    60.15,     --payment_amount
    '11',       --image_file_front
    '12',      --image_file_rear
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'ABC',     --text_1
    '156551',  --bank_account
    '1565168'  --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, image_file_front, 
  image_file_rear, item_source, item_status, matched_payment_seq, text_1, 
  bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    40,        --item_ref
    12.25,     --payment_amount
    '13',       --image_file_front
    '14',      --image_file_rear
    1,         --item_source
    2,         --item_status
    2,         --matched_payment_seq
    'DEF',     --text_1
    '8989189', --bank_account
    '56658'    --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, image_file_front, 
  image_file_rear, item_source, item_status, matched_payment_seq, text_1, 
  bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    70,        --item_ref
    55.55,     --payment_amount
    '15',       --image_file_front
    '16',      --image_file_rear
    1,         --item_source
    2,         --item_status
    3,         --matched_payment_seq
    'GHI',     --text_1
    '3545304', --bank_account
    '76882'    --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, image_file_front, 
  image_file_rear, item_source, item_status, matched_payment_seq, text_1, 
  bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    90,        --item_ref
    100.00,    --payment_amount
    '17',      --image_file_front
    '18',      --image_file_rear
    1,         --item_source
    1,         --item_status
    4,         --matched_payment_seq
    'ZZZ',     --text_1
    '2165618', --bank_account
    '28946'    --check_no
  );
