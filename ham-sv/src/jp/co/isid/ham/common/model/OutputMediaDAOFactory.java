package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 帳票出力媒体DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputMediaDAOFactory extends DaoFactory{

    /**
     * インスタンスの生成禁止
     */
    private OutputMediaDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static OutputMediaDAO createOutputMediaDAO() {
        return (OutputMediaDAO) DaoFactory.createDao(OutputMediaDAO.class);
    }
}
