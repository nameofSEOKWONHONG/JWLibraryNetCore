﻿var sql = `
    USE JWLIBRARY

    SELECT COUNT(*)
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_CATALOG = 'JWLIBRARY'
    AND TABLE_SCHEMA = 'DBO'
    AND  TABLE_NAME = 'USER'
`;