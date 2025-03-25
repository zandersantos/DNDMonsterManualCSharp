# DNDMonsterManualCSharp
A C# Web Application for Browsing and Managing a Basic Dungeons and Dragons Monster Manual

This Project will be a migration from Ruby on Rails to C# (ASP.NET) from the Introduction Project in the Fullstack Web Development Course in the Business Information Technology program at Red River College.

The main use for this Project is to experiment and explore the use of C# Web Applications, Selenium and SpecFlow.

This Project will be later refined, extended, and become a part of a larger project.

Author: Zander Santos
Dungeons and Dragons Monster Manual
  -A user is able to search a monster, action or sense and see the monsters abilities, actions, senses, and associated images.

APIS USED:
- https://www.dnd5eapi.co/api/monsters

## Models
Monster
  - id:integer (auto incrementing PK)
  - name:string
  - armour_class:int
  - hitpoints:string
  - speed:int
  - hit_dice:string
  - img_url:string

Monster_Senses
  - id:integer (auto incrementing PK)
  - sense_type:string
  - sense_range:string
  - monster_id:integer (FK)

Ability
  - id:integer (auto incrementing PK)
  - name:string
  - description:string

Monster_Ability
(Joiner Table to let Abilities have multiple Monsters)
  - id:integer (auto incrementing PK)
  - monster_id:integer (FK)
  - abilities_id:integer (FK)

Action
  - id:integer (auto incrementing PK)
  - name:string
  - description:string
  - damage_type:string
  - damage_dice:string

Monster_Action
(Joiner Table to let Actions have multiple Monsters)
  - id:integer (auto incrementing PK)
  - monster_id:integer (FK)
  - actions_id:integer (FK)

Monster_Image
  - url:string
  - monster_id:integer (FK)


-- TABLES TO HOLD QUERY RESULTS --
(ex. Holds the Action values and the total monsters that can use it - See Data Folder - )
TopActionViewModel
	- Id: Integer
	- ActionName: String
	- MonsterCount: Integer

TopSenseViewModel
	- Id: Integer
	- SenseType: String
	- MonsterCount: Integer

## Routes
GET /             => Homepage
GET /monsters     => Display a list of monsters
GET /monsters/:id => Display a single monster
GET /senses       => Display a list of monster senses
GET /senses/:id   => Display a single monster sense
GET /actions       => Display a list of monster actions
GET /actions/:id   => Display a single monster action
GET /images       => Display a list of monster image
GET /images/:id   => Display a single monster image



## Controllers
HomeController => index
MonstersController => index, show
SensesController => index, show
ActionsController => index, show
MonsterActionsController => index, show
MonsterSensesController => index, show
MonsterImagesController => index, show
