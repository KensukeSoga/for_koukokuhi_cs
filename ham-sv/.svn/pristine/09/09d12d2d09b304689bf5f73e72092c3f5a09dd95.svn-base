package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.integ.DaoFactory;

/**
*
* <P>
* 素材一覧(共通)DAOFactory
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/03/10 HDX対応 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateMaterialListCmnDAOFactory extends DaoFactory {

	/**
	 * インスタンス禁止のため、privateにて実装
	 */
	private UpdateMaterialListCmnDAOFactory() {

	}

    /**
     * RegisterLogMaterialListCmnDAOを取得します
     * @return
     */
    public static UpdateMaterialListCmnDAO createUpdateMaterialListCmnDAO() {
        return (UpdateMaterialListCmnDAO) DaoFactory.createDao(UpdateMaterialListCmnDAO.class);
    }
}