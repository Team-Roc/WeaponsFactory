-- WeaponsFactory.MySql.DataAccess.Sale
CREATE TABLE `Sale` (
    `Income` numeric(20,10) NOT NULL,       -- _income
    `Quantity` integer NOT NULL,            -- _quantity
    `SaleId` integer NOT NULL,              -- _saleId
    `VendorName` varchar(255) NULL,         -- _vendorName
    `WeaponId` integer NOT NULL,            -- _weaponId
    `WeaponName` varchar(255) NULL,         -- _weaponName
    CONSTRAINT `pk_Sale` PRIMARY KEY (`SaleId`)
) ENGINE = InnoDB
;

