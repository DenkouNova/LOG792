
-- =============================================================================
-- Script de cr�ation de base de donn�es.
-- On cr�e les tables avec un script car l'outil SQLite Browser ne permet pas
-- de cr�er les tables avec des cl�s �trang�res (Foreign Key)
-- 
-- Historique
-- v1.00 - pas de script, fichier cr�� dans SqLite Browser
-- v1.01 - pas de script, fichier cr�� dans SqLite Browser
-- v1.02 - version initiale de script, avec seulement les tables CTEC et le lot 256001
-- v1.03 - image_extract_archive, image_extract_condition_links, image_extract_ccg, 
--           image_extract_cond_cat_dictionary, image_extract_conditions,
--           image_extract_condition_set, image_extract
-- v1.04 - 
-- v1.05 - chang� le naming de plusieurs tables et configs pour les tables IE
--           imgextr_config, imgextr_archive, imgextr_cond_set_configs,
--           imgextr_cond_set, imgextr_cond_set_conditions, imgextr_condition,
--           imgextr_cond_cat_conditions, imgextr_cond_category
-- =============================================================================

-- =============================================================================
-- On efface toutes les tables de base CTEC en ordre de cl�s �trang�res
-- =============================================================================
DROP TABLE IF EXISTS item_payment;
DROP TABLE IF EXISTS item_statement;
DROP TABLE IF EXISTS matched_payment;
DROP TABLE IF EXISTS capture_batch;
DROP TABLE IF EXISTS statement_definition;
DROP TABLE IF EXISTS capture_site_definition;

-- =============================================================================
-- On efface toutes les tables reli�es � l'Extraction d'Image en ordre de cl�s �trang�res
-- =============================================================================

--drop current tables
DROP TABLE IF EXISTS imgextr_cond_set_configs;
DROP TABLE IF EXISTS imgextr_cond_cat_conditions;
DROP TABLE IF EXISTS imgextr_cond_category;
DROP TABLE IF EXISTS imgextr_cond_set_conditions;
DROP TABLE IF EXISTS imgextr_cond_set;
DROP TABLE IF EXISTS imgextr_condition;
DROP TABLE IF EXISTS imgextr_archive;
DROP TABLE IF EXISTS imgextr_config;

-- =============================================================================
-- On ins�re les tables de base CTEC
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
  'batch_seq' INTEGER NOT NULL,
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
  'item_source' TEXT NOT NULL,
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
  'item_source' TEXT NOT NULL,
  'item_status' TEXT,
  'matched_payment_seq' INTEGER NOT NULL,
  'text_1' TEXT,
  'transaction_reference' TEXT,
  PRIMARY KEY(batch_seq, item_ref),
  FOREIGN KEY(batch_seq, matched_payment_seq)
    REFERENCES matched_payment(batch_seq, matched_payment_seq)
);

-- =============================================================================
-- On ins�re les tables reli�es � l'Extraction d'Image
-- =============================================================================

CREATE TABLE 'imgextr_config' (
  'imgextr_config_id' INTEGER,
  'statement_id' INTEGER,
  'image_naming' TEXT,
  'encoding_config_path' TEXT,
  'endorsement_config_path' TEXT,
  PRIMARY KEY(imgextr_config_id),
  FOREIGN KEY(statement_id) REFERENCES capture_batch(statement_id)
);

CREATE TABLE 'imgextr_condition' (
  'condition_id' INTEGER,
  'description' TEXT NOT NULL,
  'where_clause' TEXT  NOT NULL,
  PRIMARY KEY(condition_id)
);


CREATE TABLE 'imgextr_archive' (
  'imgextr_config_id' INTEGER,
  'archive_naming' TEXT NOT NULL,
  'archive_type' TEXT NOT NULL, --CHECK(archive_type IN ('zip', 'tar', 'tar.gz')),
  PRIMARY KEY(imgextr_config_id),
  FOREIGN KEY(imgextr_config_id) REFERENCES imgextr_config(imgextr_config_id)
);

CREATE TABLE 'imgextr_cond_set' (
  'cond_set_id' INTEGER,
  PRIMARY KEY(cond_set_id)
);

CREATE TABLE 'imgextr_cond_set_conditions' (
  'cond_set_id' INTEGER,
  'condition_id' INTEGER,
  PRIMARY KEY(cond_set_id, condition_id)
);

CREATE TABLE 'imgextr_cond_category' (
  'cond_category_id' INTEGER,
  'description' TEXT,
  PRIMARY KEY (cond_category_id)
);

CREATE TABLE 'imgextr_cond_cat_conditions' (
  'cond_category_id' INTEGER,
  'condition_id' INTEGER,
  PRIMARY KEY(cond_category_id, condition_id),
  FOREIGN KEY(cond_category_id) REFERENCES imgextr_cond_category(cond_category_id),
  FOREIGN KEY(condition_id) REFERENCES imgextr_condition(condition_id)
);

CREATE TABLE 'imgextr_cond_set_configs' (
  'imgextr_config_id' INTEGER,
  'cond_set_id' INTEGER,
  PRIMARY KEY(imgextr_config_id, cond_set_id),
  FOREIGN KEY(imgextr_config_id) REFERENCES imgextr_config(imgextr_config_id),
  FOREIGN KEY(cond_set_id) REFERENCES imgextr_cond_set(cond_set_id)
);


-- =============================================================================
-- Insertion de donn�es CTEC - CAPTURE_SITE_DEFINITION
-- =============================================================================

INSERT INTO capture_site_definition(site_id, description) VALUES (0, 'Addison, IL');
INSERT INTO capture_site_definition(site_id, description) VALUES (1, 'Irving, TX');
INSERT INTO capture_site_definition(site_id, description) VALUES (3, 'Charlotte, NC');

-- =============================================================================
-- Insertion de donn�es CTEC - STATEMENT_DEFINITION
-- =============================================================================

INSERT INTO statement_definition(statement_id, home_site, description) VALUES(1319, 3, 'CTLK');
INSERT INTO statement_definition(statement_id, home_site, description) VALUES(4331, 0, 'ASAWDP');
INSERT INTO statement_definition(statement_id, home_site, description) VALUES(4366, 0, 'ASAWDH');

-- =============================================================================
-- Insertion de donn�es CTEC - CAPTURE_BATCH
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
-- Insertion de donn�es CTEC - MATCHED_PAYMENT
--                             FK sur capture_batch
-- =============================================================================

-- possibilit�s de matched_payment_status (voir dictionnaire BD):
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
-- Insertion de donn�es CTEC - ITEM_STATEMENT
--                             FK sur matched_payment
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
-- Insertion de donn�es CTEC - ITEM_PAYMENT
--                             FK sur matched_payment
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

-- =============================================================================
-- Insertion de donn�es IE - imgextr_config
-- =============================================================================

INSERT INTO imgextr_config(imgextr_config_id, statement_id, image_naming, encoding_config_path, 
  endorsement_config_path)
  VALUES
  (
    1,     --imgextr_config_id
    1319,  --statement_id
    'abc', --image_naming
    'def', --encoding_config_path
    'ghi'  --endorsement_config_path
  );

-- =============================================================================
-- Insertion de donn�es IE - IMAGE_EXTRACT_ARCHIVE
-- =============================================================================

INSERT INTO imgextr_archive(imgextr_config_id, archive_naming, archive_type)
  VALUES
  (
    1,     --imgextr_config_id
    'ImgExtr_($STATEMENT_ID, 8).zip',  --archive_naming
    'zip'  --archive_type
  );

  /*
-- =============================================================================
-- Insertion de donn�es IE - IMAGE_EXTRACT_CONDITION_SET
-- =============================================================================

INSERT INTO image_extract_condition_set(condition_set_id, imgextr_config_id)
  VALUES
  (
    1, --condition_set_id
    1  --imgextr_config_id
  );
*/
  
-- =============================================================================
-- Insertion de donn�es IE - imgextr_condition
-- =============================================================================

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    1, --condition_id
    'Multiples', --description
    'Capture_Batch.Capture_Type_Item = 1' --where_clause
  );
  
INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    2, --condition_id
    'Singles', --description
    'Capture_Batch.Capture_Type_Item = 2' --where_clause
  );
  
INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    3, --condition_id
    'Check Only', --description
    'Capture_Batch.Capture_Type_Item = 3' --where_clause
  );

-- =============================================================================
-- Insertion de donn�es IE - imgextr_cond_set
-- =============================================================================

INSERT INTO imgextr_cond_set(cond_set_id)
  VALUES
  (
    1 --cond_set_id
  );
  
-- =============================================================================
-- Insertion de donn�es IE - imgextr_cond_set_conditions
-- =============================================================================

INSERT INTO imgextr_cond_set_conditions(cond_set_id, condition_id)
  VALUES
  (
    1, --cond_set_id
    1  --condition_id
  );

INSERT INTO imgextr_cond_set_conditions(cond_set_id, condition_id)
  VALUES
  (
    1, --cond_set_id
    3  --condition_id
  );

-- =============================================================================
-- Insertion de donn�es IE - imgextr_cond_category
-- =============================================================================
  
INSERT INTO imgextr_cond_category(cond_category_id, description)
  VALUES
  (
    1, --cond_category_id
    'Batch type' --description
  );
  
-- =============================================================================
-- Insertion de donn�es IE - imgextr_cond_cat_conditions
-- =============================================================================
  
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id)
  VALUES
  (
    1, --cond_category_id
    '1' --condition_id
  );
  
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id)
  VALUES
  (
    1, --cond_category_id
    '2' --condition_id
  );

INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id)
  VALUES
  (
    1, --cond_category_id
    '3' --condition_id
  );

-- =============================================================================
-- Insertion de donn�es IE - imgextr_cond_set_configs
-- =============================================================================
  
INSERT INTO imgextr_cond_set_configs(imgextr_config_id, cond_set_id)
  VALUES
  (
    1, --imgextr_config_id
    1 --cond_set_id
  );




