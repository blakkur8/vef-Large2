-- Create a few players
-- Assign pokemons to their inventories
-- Create multiple battles, in different states, 

INSERT INTO "Players" ("Name", "Deleted") VALUES ('Sigmar', FALSE);  -- Sigmar has id 1
INSERT INTO "Players" ("Name", "Deleted") VALUES ('Pétur', FALSE); -- 2
INSERT INTO "Players" ("Name", "Deleted") VALUES ('Helgi', FALSE); -- 3
INSERT INTO "Players" ("Name", "Deleted") VALUES ('Gummi', FALSE); -- 4
INSERT INTO "Players" ("Name", "Deleted") VALUES ('Jónas', FALSE); -- 5
INSERT INTO "Players" ("Name", "Deleted") VALUES ('Valdimar', FALSE); -- 6
-- Create players here ...


INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('snorlax', 1, DATE('now'));
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('eevee', 2, DATE('now'));
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('charizard', 3, DATE('now'));
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('bulbasaur', 4, DATE('now'));
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('squirtle', 5, DATE('now'));
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('dragonite', 6, DATE('now'));
-- Create inventories here ...

-- No need to create more battle statuses
INSERT INTO "BattleStatus" ("Name") VALUES ('NOT_STARTED'); -- Status id 1
INSERT INTO "BattleStatus" ("Name") VALUES ('STARTED');     -- Status id 2
INSERT INTO "BattleStatus" ("Name") VALUES ('FINISHED');    -- Status id 3

INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (NULL, 2);
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (NULL, 1);
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (3, 3);
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (4, 3);
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (2, 3);
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (6, 3);
-- Create battles here ...

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('snorlax', 1);
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('eevee', 2);
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('charizard', 3);
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('bulbasaur', 4);
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('squirtle', 5);
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('dragonite', 6);
-- Create battlepokemons here ...

INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 400, 1, 'snorlax');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 1, 'snorlax');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 3, 'charizard');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 3, 'charizard');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE , FALSE, 0, 4, 'bulbasaur');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 50, 4, 'bulbasaur');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 5, 'squirtle');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 500, 6, 'dragonite');
-- Create attacks here ...
