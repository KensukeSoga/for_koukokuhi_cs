package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * FindCarListDAO生成ファクトリクラス
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成 T.Hadate<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCarListDAOFactory extends DaoFactory {

    /**
     * インスタンス禁止のため、privateにて実装
     */
    private FindCarListDAOFactory() {
    }

    /**
     * FindCarListDAOを生成する.
     *
     * @return FindCarListDAOインスタンス
     */
    public static FindCarListDAO createFindCarListDAO() {
        return (FindCarListDAO) DaoFactory.createDao(FindCarListDAO.class);
    }
}
