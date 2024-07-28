CREATE FUNCTION TranslationPro.IsAscii(@input NVARCHAR(MAX))
RETURNS BIT
WITH SCHEMABINDING
AS
BEGIN
    DECLARE @isAscii BIT = 1;

    -- Check each character in the input string
    DECLARE @i INT = 1, @len INT = LEN(@input);
    WHILE @i <= @len
    BEGIN
        IF UNICODE(SUBSTRING(@input, @i, 1)) > 127
        BEGIN
            SET @isAscii = 0; -- Non-ASCII character found
            BREAK;
        END
        SET @i = @i + 1;
    END

    RETURN @isAscii;
END;