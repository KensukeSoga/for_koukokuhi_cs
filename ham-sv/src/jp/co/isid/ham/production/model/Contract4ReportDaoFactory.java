package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * Contract4RepportDao生成ファクトリクラス
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成 HAMメンバー<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportDaoFactory extends DaoFactory {

    /**
     * インスタンス禁止のため、privateにて実装
     */
    private Contract4ReportDaoFactory() {
        //なにもしない
    }

    /**
     * Contract4RepportDaoを生成する.
     *
     * @return Contract4RepportDaoインスタンス
     */
    public static Contract4ReportDao createContract4ReportDao() {
        return (Contract4ReportDao) DaoFactory.createDao(Contract4ReportDao.class);
    }
}
