
-- =============================================================================
-- Script de création de base de données.
-- On crée les tables avec un script car l'outil SQLite Browser ne permet pas
-- de créer les tables avec des clés étrangères (Foreign Key)
--
-- Historique
-- v1.00 - pas de script, fichier créé dans SqLite Browser
-- v1.01 - pas de script, fichier créé dans SqLite Browser
-- v1.02 - version initiale de script, avec seulement les tables CTEC et le lot 256001
-- v1.03 - image_extract_archive, image_extract_condition_links, image_extract_ccg,
--           image_extract_cond_cat_dictionary, image_extract_conditions,
--           image_extract_condition_set, image_extract
-- v1.04 -
-- v1.05 - changé le naming de plusieurs tables et configs pour les tables IE
--           imgextr_config, imgextr_archive, imgextr_cond_set_configs,
--           imgextr_cond_set, imgextr_cond_set_conditions, imgextr_condition,
--           imgextr_cond_cat_conditions, imgextr_cond_category
-- v1.06 - ajouté image_extract_config.description
-- v1.07 - ajouté capture_batch_summary
-- v1.08 - ajouté deux batches, changé les image paths
-- =============================================================================

-- =============================================================================
-- On efface toutes les tables de base CTEC en ordre de clés étrangères
-- =============================================================================
DROP TABLE IF EXISTS capture_batch_summary;
DROP TABLE IF EXISTS item_payment;
DROP TABLE IF EXISTS item_statement;
DROP TABLE IF EXISTS matched_payment;
DROP TABLE IF EXISTS capture_batch;
DROP TABLE IF EXISTS statement_definition;
DROP TABLE IF EXISTS capture_site_definition;

-- =============================================================================
-- On efface toutes les tables reliées à l'Extraction d'Image en ordre de clés étrangères
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
-- On insère les tables de base CTEC
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

CREATE TABLE 'capture_batch_summary' (
  'batch_seq' INTEGER,
  'tot_num_payments' INTEGER,
  'tot_num_statements' INTEGER,
  'tot_num_envelops' INTEGER,
  PRIMARY KEY(batch_seq),
  FOREIGN KEY(batch_seq)
    REFERENCES capture_batch(batch_seq)
);




-- =============================================================================
-- On insère les tables reliées à l'Extraction d'Image
-- =============================================================================

CREATE TABLE 'imgextr_config' (
  'imgextr_config_id' INTEGER,
  'description' TEXT,
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
  'where_clause' TEXT,
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
-- Insertion de données CTEC - CAPTURE_SITE_DEFINITION
-- =============================================================================

INSERT INTO capture_site_definition(site_id, description) VALUES (0, 'Addison, IL');
INSERT INTO capture_site_definition(site_id, description) VALUES (1, 'Irving, TX');
INSERT INTO capture_site_definition(site_id, description) VALUES (3, 'Charlotte, NC');

-- =============================================================================
-- Insertion de données CTEC - STATEMENT_DEFINITION
-- =============================================================================

INSERT INTO statement_definition(statement_id, home_site, description) VALUES(1319, 3, 'CTLK');
INSERT INTO statement_definition(statement_id, home_site, description) VALUES(4331, 0, 'ASAWDP');
INSERT INTO statement_definition(statement_id, home_site, description) VALUES(4366, 0, 'ASAWDH');

-- =============================================================================
-- Insertion de données CTEC - CAPTURE_BATCH
-- =============================================================================

INSERT INTO capture_batch(batch_seq, capture_date, capture_id, capture_type_item,
  client_batch_ref_number, custom_batch_number, exception_batch, statement_id,
  reprocessing_batch)
  VALUES
  (
    256001,     --batch_seq
    '20160609', --capture_date
    11111111,   --capture_id
    1,          --capture_type_item
    '436473',   --client_batch_ref_number
    5011,       --custom_batch_number
    null,       --exception_batch
    1319,       --statement_id
    null        --reprocessing_batch
  );

INSERT INTO capture_batch(batch_seq, capture_date, capture_id, capture_type_item,
  client_batch_ref_number, custom_batch_number, exception_batch, statement_id,
  reprocessing_batch)
  VALUES
  (
    256038,     --batch_seq
    '20160701', --capture_date
    33334444,   --capture_id
    3,          --capture_type_item
    '855195',   --client_batch_ref_number
    4388,       --custom_batch_number
    null,       --exception_batch
    1319,       --statement_id
    null        --reprocessing_batch
  );

INSERT INTO capture_batch(batch_seq, capture_date, capture_id, capture_type_item,
  client_batch_ref_number, custom_batch_number, exception_batch, statement_id,
  reprocessing_batch)
  VALUES
  (
    256164,     --batch_seq
    '20160706', --capture_date
    11111111,   --capture_id
    1,          --capture_type_item
    '432526',   --client_batch_ref_number
    5016,       --custom_batch_number
    null,       --exception_batch
    1319,       --statement_id
    null        --reprocessing_batch
  );

-- =============================================================================
-- Insertion de données CTEC - MATCHED_PAYMENT
--                             FK sur capture_batch
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

INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256038, 1, 1);
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256038, 2, 1);
  
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256164, 1, 1);
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256164, 2, 1);
INSERT INTO matched_payment(batch_seq, matched_payment_seq, matched_payment_status)
  VALUES (256164, 3, 1);

-- =============================================================================
-- Insertion de données CTEC - ITEM_STATEMENT
--                             FK sur matched_payment
-- =============================================================================

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256001,    --batch_seq
    10,        --item_ref
    60.15,     --amount_due
    60.15,     --amount_paid
    1,         --chadd_status
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    null,      --text_1
    'GALF1003' --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256001, --batch_seq
    30,     --item_ref
    30.00,  --amount_due
    12.25,  --amount_paid
    null,   --chadd_status
    1,      --item_source
    2,      --item_status
    2,      --matched_payment_seq
    null,   --text_1
    null    --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256001,    --batch_seq
    50,        --item_ref
    10.00,     --amount_due
    55.55,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    3,         --matched_payment_seq
    null,      --text_1
    '52589729' --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256001, --batch_seq
    60,     --item_ref
    null,   --amount_due
    null,   --amount_paid
    null,   --chadd_status
    1,      --item_source
    7,      --item_status
    3,      --matched_payment_seq
    null,   --text_1
    null    --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256001,     --batch_seq
    80,         --item_ref
    100.0,      --amount_due
    100.0,      --amount_paid
    0,          --chadd_status
    1,          --item_source
    1,          --item_status
    4,          --matched_payment_seq
    null,       --text_1
    'GODFP3QBC1' --transaction_reference
  );

  
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    10,        --item_ref
    31.66,     --amount_due
    31.66,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'abc',      --text_1
    'GBTTP58463' --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    20,        --item_ref
    125.23,     --amount_due
    125.23,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'def',      --text_1
    'ECTLF26152' --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    30,        --item_ref
    245.12,     --amount_due
    245.12,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'ghi',      --text_1
    'STTBC18132' --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    40,        --item_ref
    7.31,     --amount_due
    7.31,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'ghi',      --text_1
    'MSCTL11542' --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    60,        --item_ref
    12.22,     --amount_due
    12.22,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    2,         --matched_payment_seq
    'hrhah',      --text_1
    'GRCLT43908' --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    70,        --item_ref
    912.00,     --amount_due
    912.00,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    2,         --matched_payment_seq
    'helja',      --text_1
    'GRSBL89841' --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256038,    --batch_seq
    80,        --item_ref
    null,   --amount_due
    null,   --amount_paid
    null,   --chadd_status
    1,      --item_source
    7,      --item_status
    2,      --matched_payment_seq
    null,   --text_1
    null    --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256164,    --batch_seq
    10,        --item_ref
    153.26,     --amount_due
    153.26,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    '35326',      --text_1
    'KYONY49841' --transaction_reference
  );

INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256164,    --batch_seq
    30,        --item_ref
    241.14,     --amount_due
    241.14,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    2,         --matched_payment_seq
    '35326',      --text_1
    'MANPP41424' --transaction_reference
  );
  
INSERT INTO item_statement(batch_seq, item_ref, amount_due, amount_paid, chadd_status,
  item_source, item_status, matched_payment_seq, text_1, transaction_reference)
  VALUES
  (
    256164,    --batch_seq
    50,        --item_ref
    1231.55,     --amount_due
    1231.55,     --amount_paid
    0,         --chadd_status
    1,         --item_source
    1,         --item_status
    3,         --matched_payment_seq
    '35151',      --text_1
    'TADAI98944' --transaction_reference
  );

  
  
-- =============================================================================
-- Insertion de données CTEC - ITEM_PAYMENT
--                             FK sur matched_payment
-- =============================================================================

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    20,        --item_ref
    60.15,     --payment_amount
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'ABC',     --text_1
    '156551',  --bank_account
    '1565168'  --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    40,        --item_ref
    12.25,     --payment_amount
    1,         --item_source
    2,         --item_status
    2,         --matched_payment_seq
    'DEF',     --text_1
    '8989189', --bank_account
    '56658'    --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    70,        --item_ref
    55.55,     --payment_amount
    1,         --item_source
    2,         --item_status
    3,         --matched_payment_seq
    'GHI',     --text_1
    '3545304', --bank_account
    '76882'    --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256001,    --batch_seq
    90,        --item_ref
    100.00,    --payment_amount
    1,         --item_source
    1,         --item_status
    4,         --matched_payment_seq
    'ZZZ',     --text_1
    '2165618', --bank_account
    '28946'    --check_no
  );

INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256038,    --batch_seq
    50,        --item_ref
    409.32,    --payment_amount
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'FHJEHYTA',     --text_1
    '543436', --bank_account
    '2345'    --check_no
  );
  
INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256038,    --batch_seq
    90,        --item_ref
    924.22,    --payment_amount
    1,         --item_source
    1,         --item_status
    2,         --matched_payment_seq
    'HFAJRH',     --text_1
    '6547542', --bank_account
    '23357'    --check_no
  );
  
INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256164,    --batch_seq
    20,        --item_ref
    153.26,    --payment_amount
    1,         --item_source
    1,         --item_status
    1,         --matched_payment_seq
    'HERHA',     --text_1
    '3456256', --bank_account
    '62621'    --check_no
  );
  
INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256164,    --batch_seq
    40,        --item_ref
    241.14,    --payment_amount
    1,         --item_source
    1,         --item_status
    2,         --matched_payment_seq
    '76599',     --text_1
    '2532632', --bank_account
    '68788'    --check_no
  );
  
INSERT INTO item_payment(batch_seq, item_ref, payment_amount, item_source,
  item_status, matched_payment_seq, text_1, bank_account, check_no)
  VALUES
  (
    256164,    --batch_seq
    60,        --item_ref
    1231.55,    --payment_amount
    1,         --item_source
    1,         --item_status
    3,         --matched_payment_seq
    '15111',     --text_1
    '4344367', --bank_account
    '43666'    --check_no
  );
  
-- =============================================================================
-- Insertion de données CTEC - CAPTURE_BATCH_SUMMARY
--                             FK sur capture_batch
-- =============================================================================

-- dans le vrai système CTEC, ces données sont insérées par un trigger
INSERT INTO Capture_Batch_Summary
SELECT
  cb.Batch_Seq,
    (SELECT COUNT(*) FROM Item_Payment WHERE Batch_Seq = cb.Batch_Seq) AS Tot_Num_Payments,
    (SELECT COUNT(*) FROM Item_Statement WHERE Batch_Seq = cb.Batch_Seq) AS Tot_Num_Statements,
    (SELECT COUNT(*) FROM Matched_Payment WHERE Batch_Seq = cb.Batch_Seq) AS Tot_Num_Envelops
FROM
  Capture_Batch cb
;

-- =============================================================================
-- Insertion de données IE - imgextr_config
-- =============================================================================

INSERT INTO imgextr_config(imgextr_config_id, description, statement_id, image_naming, encoding_config_path,
  endorsement_config_path)
  VALUES
  (
    1,     --imgextr_config_id
    '1319 IE Config', --description
    1319,  --statement_id
    'abc', --image_naming
    'def', --encoding_config_path
    'ghi'  --endorsement_config_path
  );

-- =============================================================================
-- Insertion de données IE - IMAGE_EXTRACT_ARCHIVE
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
-- Insertion de données IE - IMAGE_EXTRACT_CONDITION_SET
-- =============================================================================

INSERT INTO image_extract_condition_set(condition_set_id, imgextr_config_id)
  VALUES
  (
    1, --condition_set_id
    1  --imgextr_config_id
  );
*/

-- =============================================================================
-- Insertion de données IE - imgextr_condition
-- =============================================================================

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    1, --condition_id
    'Batches: Multiples', --description
    'Capture_Batch.Capture_Type_Item = 1' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    2, --condition_id
    'Batches: Singles', --description
    'Capture_Batch.Capture_Type_Item = 2' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    3, --condition_id
    'Batches: Check Only', --description
    'Capture_Batch.Capture_Type_Item = 3' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    4, --condition_id
    'Batches: Check Only No Virtual', --description
    'Capture_Batch.Capture_Type_Item = 7' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    5, --condition_id
    'Batches: Check Skirt', --description
    'Capture_Batch.Capture_Type_Item = 8' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    6, --condition_id
    'Batches: Returns', --description
    'Capture_Batch.Capture_Type_Item = 9' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    7, --condition_id
    'Transaction Status: Automatically Matched', --description
    'Matched_Payment.Matched_Payment_Status = 1' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    8, --condition_id
    'Transaction Status: Manually Matched', --description
    'Matched_Payment.Matched_Payment_Status = 2' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    9, --condition_id
    'Transaction Status: Rejected Items', --description
    'Matched_Payment.Matched_Payment_Status = 3' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    10, --condition_id
    'Transaction Status: Rejected Envelope', --description
    'Matched_Payment.Matched_Payment_Status = 4' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    11, --condition_id
    'Item Source (Payment): Captured Items', --description
    'Item_Payment.Item_Source = 1' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    12, --condition_id
    'Item Source (Payment): Virtual Items', --description
    'Item_Payment.Item_Source = 2' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    13, --condition_id
    'Item Source (Statement): Captured Items', --description
    'Item_Statement.Item_Source = 1' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    14, --condition_id
    'Item Source (Statement): Virtual Items', --description
    'Item_Statement.Item_Source = 2' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    15, --condition_id
    'All items', --description
    null --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    16, --condition_id
    'Front images', --description
    '%FRONT_ONLY%' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    17, --condition_id
    'Rear images', --description
    '%REAR_ONLY%' --where_clause
  );

INSERT INTO imgextr_condition(condition_id, description, where_clause)
  VALUES
  (
    18, --condition_id
    'Items with CHADD', --description
    'Item_Statement.Chadd_Status = 1' --where_clause
  );
  
-- =============================================================================
-- Insertion de données IE - imgextr_cond_set
-- =============================================================================

INSERT INTO imgextr_cond_set(cond_set_id)
  VALUES
  (
    1 --cond_set_id
  );

-- =============================================================================
-- Insertion de données IE - imgextr_cond_set_conditions
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
-- Insertion de données IE - imgextr_cond_category
-- =============================================================================

INSERT INTO imgextr_cond_category(cond_category_id, description) VALUES (1, 'Batch type');
INSERT INTO imgextr_cond_category(cond_category_id, description) VALUES (2, 'Transaction status');
INSERT INTO imgextr_cond_category(cond_category_id, description) VALUES (3, 'Item source');
INSERT INTO imgextr_cond_category(cond_category_id, description) VALUES (4, 'Misc');
INSERT INTO imgextr_cond_category(cond_category_id, description) VALUES (5, 'CHADD');

-- =============================================================================
-- Insertion de données IE - imgextr_cond_cat_conditions
-- =============================================================================

INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (1, 1);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (1, 2);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (1, 3);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (1, 4);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (1, 5);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (1, 6);

INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (2, 7);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (2, 8);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (2, 9);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (2, 10);

INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (3, 11);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (3, 12);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (3, 13);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (3, 14);

INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (4, 15);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (4, 16);
INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (4, 17);

INSERT INTO imgextr_cond_cat_conditions(cond_category_id, condition_id) VALUES (5, 18);

-- =============================================================================
-- Insertion de données IE - imgextr_cond_set_configs
-- =============================================================================

INSERT INTO imgextr_cond_set_configs(imgextr_config_id, cond_set_id)
  VALUES
  (
    1, --imgextr_config_id
    1 --cond_set_id
  );





-- =============================================================================
-- Ajout d'images
-- =============================================================================

UPDATE Item_Payment SET Image_File_Front = Batch_Seq || '_' || Item_Ref || '_F';
UPDATE Item_Payment SET Image_File_Rear = Batch_Seq || '_' || Item_Ref || '_R';

UPDATE Item_Statement SET Image_File_Front = Batch_Seq || '_' || Item_Ref || '_F';
UPDATE Item_Statement SET Image_File_Rear = Batch_Seq || '_' || Item_Ref || '_R';

