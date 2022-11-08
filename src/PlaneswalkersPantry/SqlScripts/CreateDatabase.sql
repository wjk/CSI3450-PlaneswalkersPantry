-- Run this MySQL script first, as root.

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema PlaneswalkersPantry
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PlaneswalkersPantry` DEFAULT CHARACTER SET utf8 ;
USE `PlaneswalkersPantry` ;

-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`USER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`USER`;
CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`USER` (
    `USER_NAME` VARCHAR(45) NOT NULL,
    `HASHED_PASSWORD` VARCHAR(240) NOT NULL,
    `USER_TYPE` VARCHAR(50) NOT NULL DEFAULT 0 COMMENT 'Specifies if this user is a patron or an employee.',
    PRIMARY KEY (`USER_NAME`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`CARD_SET`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`CARD_SET`;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`CARD_SET` (
    `SET_CODE` VARCHAR(3) NOT NULL,
    `SET_NAME` VARCHAR(45) NOT NULL,
    `RELEASE_YEAR` INT NOT NULL,
    PRIMARY KEY (`SET_CODE`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`CARD`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`CARD`;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`CARD` (
    `CARD_NUMBER` INT NOT NULL AUTO_INCREMENT,
    `CARD_TITLE` VARCHAR(100) NOT NULL,
    `MANA_COST` VARCHAR(45) NOT NULL,
    `RULES_TEXT` VARCHAR(5000) NULL,
    `FLAVOR_TEXT` VARCHAR(5000) NULL,
    `CARD_IMAGE` BLOB NULL,
    `SET_CODE` VARCHAR(3) NOT NULL,
    `RARITY_CODE` VARCHAR(1) NOT NULL,
    `POWER` VARCHAR(10) NULL,
    `TOUGHNESS` VARCHAR(10) NULL,
    `TYPE_LINE` VARCHAR(50) NOT NULL,
    `NUMBER_OWNED` INT UNSIGNED NOT NULL,

    PRIMARY KEY (`CARD_NUMBER`),
    INDEX `fk_CARD_CARD_SET_idx` (`SET_CODE` ASC) VISIBLE,

    CONSTRAINT `fk_CARD_CARD_SET` FOREIGN KEY (`SET_CODE`)
        REFERENCES `PlaneswalkersPantry`.`CARD_SET` (`SET_CODE`) ON DELETE NO ACTION ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`DECK`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`DECK`;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`DECK`
(
    `DECK_NUMBER` INT          NOT NULL AUTO_INCREMENT,
    `DECK_TITLE`  VARCHAR(100) NOT NULL,
    `DECK_COLORS` VARCHAR(5)   NULL,
    PRIMARY KEY (`DECK_NUMBER`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`CARD_IN_DECK`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`CARD_IN_DECK`;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`CARD_IN_DECK` (
    `DECK_NUMBER` INT NOT NULL,
    `CARD_NUMBER` INT NOT NULL,
    `COUNT` INT UNSIGNED NOT NULL,

    PRIMARY KEY (`DECK_NUMBER`, `CARD_NUMBER`),
    INDEX `fk_DECK_has_CARD_CARD1_idx` (`CARD_NUMBER` ASC) VISIBLE,
    INDEX `fk_DECK_has_CARD_DECK1_idx` (`DECK_NUMBER` ASC) VISIBLE,
    CONSTRAINT `fk_DECK_has_CARD_DECK1` FOREIGN KEY (`DECK_NUMBER`)
        REFERENCES `PlaneswalkersPantry`.`DECK` (`DECK_NUMBER`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_DECK_has_CARD_CARD1` FOREIGN KEY (`CARD_NUMBER`)
            REFERENCES `PlaneswalkersPantry`.`CARD` (`CARD_NUMBER`) ON DELETE NO ACTION ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`CHECKOUT`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`CHECKOUT`;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`CHECKOUT` (
    `CHECKOUT_NUMBER` INT NOT NULL,
    `DUE_DATE` DATETIME NOT NULL,
    `USER_NAME` VARCHAR(45) NOT NULL,

    PRIMARY KEY (`CHECKOUT_NUMBER`),
    INDEX `fk_CHECKOUT_USER1_idx` (`USER_NAME` ASC) VISIBLE,
    CONSTRAINT `fk_CHECKOUT_USER1` FOREIGN KEY (`USER_NAME`)
        REFERENCES `PlaneswalkersPantry`.`USER` (`USER_NAME`) ON DELETE NO ACTION ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`DECK_IN_CHECKOUT`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`DECK_IN_CHECKOUT`;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`DECK_IN_CHECKOUT` (
    `CHECKOUT_NUMBER` INT NOT NULL,
    `DECK_NUMBER` INT NOT NULL,
    `COUNT` INT UNSIGNED NOT NULL,

    PRIMARY KEY (`CHECKOUT_NUMBER`, `DECK_NUMBER`),
    INDEX `fk_CARD_IN_CHECKOUT_CHECKOUT1_idx` (`CHECKOUT_NUMBER` ASC) VISIBLE,
    INDEX `fk_CARD_IN_CHECKOUT_DECK1_idx` (`DECK_NUMBER` ASC) VISIBLE,

    CONSTRAINT `fk_CARD_IN_CHECKOUT_CHECKOUT1` FOREIGN KEY (`CHECKOUT_NUMBER`)
        REFERENCES `PlaneswalkersPantry`.`CHECKOUT` (`CHECKOUT_NUMBER`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_CARD_IN_CHECKOUT_DECK1` FOREIGN KEY (`DECK_NUMBER`)
        REFERENCES `PlaneswalkersPantry`.`DECK` (`DECK_NUMBER`) ON DELETE NO ACTION ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PlaneswalkersPantry`.`CARD_IN_CHECKOUT`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `PlaneswalkersPantry`.`CARD_IN_CHECKOUT` ;

CREATE TABLE IF NOT EXISTS `PlaneswalkersPantry`.`CARD_IN_CHECKOUT` (
    `CHECKOUT_NUMBER` INT NOT NULL,
    `CARD_NUMBER` INT NOT NULL,
    `COUNT` INT UNSIGNED NOT NULL,

    PRIMARY KEY (`CARD_NUMBER`, `CHECKOUT_NUMBER`),
    INDEX `fk_CHECKOUT_has_CARD_CARD1_idx` (`CARD_NUMBER` ASC) VISIBLE,
    INDEX `fk_CHECKOUT_has_CARD_CHECKOUT1_idx` (`CHECKOUT_NUMBER` ASC) VISIBLE,
    CONSTRAINT `fk_CHECKOUT_has_CARD_CHECKOUT1` FOREIGN KEY (`CHECKOUT_NUMBER`)
        REFERENCES `PlaneswalkersPantry`.`CHECKOUT` (`CHECKOUT_NUMBER`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_CHECKOUT_has_CARD_CARD1` FOREIGN KEY (`CARD_NUMBER`)
        REFERENCES `PlaneswalkersPantry`.`CARD` (`CARD_NUMBER`) ON DELETE NO ACTION ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- User PlaneswalkersPantry
-- -----------------------------------------------------
CREATE USER IF NOT EXISTS 'PlaneswalkersPantry' IDENTIFIED BY 'PlaneswalkersPantry123';
GRANT INSERT, SELECT, UPDATE, DELETE ON PlaneswalkersPantry.* TO 'PlaneswalkersPantry';
