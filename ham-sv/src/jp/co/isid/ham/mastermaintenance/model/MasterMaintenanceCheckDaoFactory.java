package jp.co.isid.ham.mastermaintenance.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * マスタメンテナンスチェック用DAOFaotory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
public class MasterMaintenanceCheckDaoFactory extends DaoFactory
{
    /**
    * インスタンス化を禁止します
    */
    private MasterMaintenanceCheckDaoFactory()
    {
    }

    /**
    * DAOインスタンスを生成します
    * @return DAOインスタンス
    */
    public static MasterMaintenanceCheckDao createMasterMaintenanceCheckDao()
    {
        return (MasterMaintenanceCheckDao) DaoFactory.createDao(MasterMaintenanceCheckDao.class);
    }

}
