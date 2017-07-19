package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 排他チェック用DAOFaotory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 森)<BR>
 * </P>
 * @author 森
 */
public class RegistExclusionDaoFactory extends DaoFactory
{
    /**
    * インスタンス化を禁止します
    */
    private RegistExclusionDaoFactory()
    {
    }

    /**
    * DAOインスタンスを生成します
    * @return DAOインスタンス
    */
    public static RegistExclusionDao createRegistExclusionDao()
    {
        return (RegistExclusionDao) DaoFactory.createDao(RegistExclusionDao.class);
    }

}
