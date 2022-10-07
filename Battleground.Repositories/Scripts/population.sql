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

-- Each player has one pokemon in their inventory
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('snorlax', 1, DATE('now'));   -- Add snorlax to Sigmar's inventory
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('eevee', 2, DATE('now'));     -- Add eevee to Pétur's inventory
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('charizard', 3, DATE('now')); -- Add charizard to Helgi's inventory
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('bulbasaur', 4, DATE('now')); -- Add bulbasaur to Gummi's inventory
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('squirtle', 5, DATE('now'));  -- Add squirtle to Jónas's inventory
INSERT INTO "PlayerInventories" ("PokemonIdentifier", "PlayerId", "AcquiredDate") VALUES ('dragonite', 6, DATE('now')); -- Add dragonite to Valdimar's inventory
-- Create inventories here ...

-- No need to create more battle statuses
INSERT INTO "BattleStatus" ("Name") VALUES ('NOT_STARTED'); -- Status id 1
INSERT INTO "BattleStatus" ("Name") VALUES ('STARTED');     -- Status id 2
INSERT INTO "BattleStatus" ("Name") VALUES ('FINISHED');    -- Status id 3

INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (NULL, 2);    -- Battle has started   | No winner
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (NULL, 1);    -- Battle not started   | No winner
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (3, 3);       -- Battle has finished  | Helgi won
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (4, 3);       -- Battle has finished  | Gummi won
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (2, 3);       -- Battle has finished  | Pétur won
INSERT INTO "Battles" ("WinnerId", "StatusId") VALUES (6, 3);       -- Battle has finished  | Valdimar won
-- Create battles here ...

-- Create players in battle ...
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (1, 3); -- Add Helgi to battle 1
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (1, 1); -- Add Sigmar to battle 1

INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (2, 5); -- Add Jónas to battle 2
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (2, 4); -- Add Gummi to battle 2

INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (3, 2); -- Add Pétur to battle 3
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (3, 3); -- Add Helgi to battle 3

INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (4, 6); -- Add Valdimar to battle 4
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (4, 5); -- Add Jónas to battle 4

INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (5, 4); -- Add Gummi to battle 5
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (5, 3); -- Add Helgi to battle 5

INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (6, 2); -- Add Pétur to battle 6
INSERT INTO "BattlePlayer" ("BattleId", "PlayerInMatchId") VALUES (6, 5); -- Add Jónas to battle 6


INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('snorlax', 1);   -- Helgi vs Sigmar | Add snorlax (Sigmar's pokemon)
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('charizard', 1); -- Helgi vs Sigmar | Add charizard (Helgi's pokemon)

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('squirtle', 2);  -- Jónas vs Gummi | Add squirtle (Jónas's pokemon)
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('bulbasaur', 2); -- Jónas vs Gummi | Add bulbasaur (Gummi's pokemon)

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('eevee', 3);     -- Pétur vs Helgi | Add eevee (Pétur's pokemon)
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('charizard', 3); -- Pétur vs Helgi | Add charizard (Helgi's pokemon)

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('dragonite', 4); -- Valdimar vs Jónas | Add dragonite (Valdimar's pokemon)
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('squirtle', 4);  -- Valdimar vs Jónas | Add squirtle (Jónas's pokemon)

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('bulbasaur', 5); -- Gummi vs Helgi | Add bulbasaur (Gummi's pokemon)
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('charizard', 5); -- Gummi vs Helgi | Add charizard (Helgi's pokemon)

INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('eevee', 6);     -- Pétur vs Jónas | Add eevee (Pétur's pokemon)
INSERT INTO "BattlePokemons" ("PokemonIdentifier", "BattleId") VALUES ('squirtle', 6);  -- Pétur vs Jónas | Add squirtle (Jónas's pokemon)
-- Create battlepokemons here ...

-- Helgi (snorlax) vs Sigmar (charizard) | Battle 1 | Attacks
-- No attacks yet, game not started...

-- Jónas (squirtle) vs Gummi (bulbasaur) | Battle 2 | Attacks
-- No attacks yet, game not started...

-- Pétur (eevee) vs Helgi (charizard) | Battle 3 | Attacks
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 3, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 3, 'charizard');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 3, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 400, 3, 'charizard');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 3, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 3, 'charizard');

-- Valdimar (dragonite) vs Jónas (squirtle) | Battle 4 | Attacks
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 4, 'dragonite');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 4, 'squirtle');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 4, 'dragonite');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 400, 4, 'squirtle');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 4, 'dragonite');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 4, 'squirtle');

-- Gummi (bulbasaur) vs Helgi (charizard) | Battle 5 | Attacks
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 5, 'bulbasaur');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 5, 'charizard');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 5, 'bulbasaur');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 400, 5, 'charizard');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 5, 'bulbasaur');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 5, 'charizard');

-- Pétur (eevee) vs Jónas (squirtle) | Battle 6 | Attacks
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 400, 6, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE, FALSE, 0, 6, 'squirtle');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 6, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 350, 6, 'squirtle');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (FALSE , FALSE, 0, 6, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 50, 6, 'squirtle');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, FALSE, 200, 6, 'eevee');
INSERT INTO "Attacks" ("Success", "CriticalHit", "Damage", "BattleId", "BattlePokemonIdentifier") VALUES (TRUE, TRUE, 500, 6, 'squirtle');
-- Create attacks here ...
