-- Create a few players
-- Assign pokemons to their inventories
-- Create multiple battles, in different states, 

INSERT INTO "Players" ("Name", "Deleted") VALUES ('Sigmar', FALSE);  -- Sigmar has id 1
-- Create players here ...


INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('snorlax', 1, DATE('now'));
-- Create inventories here ...

-- No need to create more battle statuses
INSERT INTO "BattleStatus" ("Name") VALUES ('NOT_STARTED'); -- Status id 1
INSERT INTO "BattleStatus" ("Name") VALUES ('STARTED');     -- Status id 2
INSERT INTO "BattleStatus" ("Name") VALUES ('FINISHED');    -- Status id 3

INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (NULL, 2);
-- Create battles here ...

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('snorlax', 1);
-- Create battlepokemons here ...

INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 400, 1, 'snorlax');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 1, 'snorlax');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 1, 'snorlax');
-- Create attacks here ...
