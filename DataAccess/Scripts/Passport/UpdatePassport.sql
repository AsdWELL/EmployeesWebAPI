﻿UPDATE "Passports"
SET
	"Type" = COALESCE(@Type, "Type"),
	"Number" = COALESCE(@Number, "Number")
WHERE "Id" = @Id