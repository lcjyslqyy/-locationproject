if exists (select 1
            from  sysobjects
           where  id = object_id('lp_userinfo')
            and   type = 'U')
   drop table lp_userinfo
go

/*==============================================================*/
/* Table: lp_userinfo                                           */
/*==============================================================*/
create table lp_userinfo (
   openid               varchar(50)          not null,
   uname                varchar(100)         not null,
   uphone               varchar(50)          not null,
   ustatus              int                  not null,
   issystem             int                  not null,
   createtime           datetime             not null,
   constraint PK_LP_USERINFO primary key (openid)
)
go



if exists (select 1
            from  sysindexes
           where  id    = object_id('lp_sourcelocation')
            and   name  = 'Index_tlid'
            and   indid > 0
            and   indid < 255)
   drop index lp_sourcelocation.Index_tlid
go

if exists (select 1
            from  sysobjects
           where  id = object_id('lp_sourcelocation')
            and   type = 'U')
   drop table lp_sourcelocation
go

/*==============================================================*/
/* Table: lp_sourcelocation                                     */
/*==============================================================*/
create table lp_sourcelocation (
   slid                 varchar(50)          not null,
   tlid                 varchar(50)          not null,
   openid               varchar(50)          not null,
   startouttime         varchar(50)          not null,
   addressdes           varchar(500)         not null,
   havecar              int                  not null,
   starttype            int                  not null,
   lat                  decimal(10,6)        not null,
   lng                  decimal(10,6)        not null,
   leftseat             int                  not null,
   createtime           datetime             not null,
   slstatus             int                  not null,
   constraint PK_LP_SOURCELOCATION primary key (slid)
)
go

/*==============================================================*/
/* Index: Index_tlid                                            */
/*==============================================================*/
create index Index_tlid on lp_sourcelocation (
tlid ASC
)
go


if exists (select 1
            from  sysobjects
           where  id = object_id('lp_targetlocation')
            and   type = 'U')
   drop table lp_targetlocation
go

/*==============================================================*/
/* Table: lp_targetlocation                                     */
/*==============================================================*/
create table lp_targetlocation (
   tlid                 varchar(50)          not null,
   lat                  decimal(10,6)        not null,
   lng                  decimal(10,6)        not null,
   tlname               varchar(500)         not null,
   createtime           datetime             not null,
   tlstatus             int                  not null,
   constraint PK_LP_TARGETLOCATION primary key (tlid)
)
go
