package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.integ.DaoFactory;

/**
*
* <P>
* 素材一覧(共通OA期間)DAOFactory
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/03/10 HDX対応 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateMaterialListCmnOADAOFactory extends DaoFactory {

	/**
	 * インスタンス禁止のため、privateにて実装
	 */
	private UpdateMaterialListCmnOADAOFactory() {

	}

    /**
     * RegisterLogMaterialListCmnOADAOを取得します
     * @return
     */
    public static UpdateMaterialListCmnOADAO createUpdateMaterialListCmnOADAO() {
        return (UpdateMaterialListCmnOADAO) DaoFactory.createDao(UpdateMaterialListCmnOADAO.class);
    }
}