package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 帳票出力車種DAOFactory
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputCarDAOFactory extends DaoFactory{
    /**
     * インスタンスの生成禁止
     */
    private OutputCarDAOFactory() {
    }

    /**
     * DAOインスタンスを生成する
     *
     * @return DAOインスタンス
     */
    public static OutputCarDAO createOutputCarDAO() {
        return (OutputCarDAO) DaoFactory.createDao(OutputCarDAO.class);
    }
}
