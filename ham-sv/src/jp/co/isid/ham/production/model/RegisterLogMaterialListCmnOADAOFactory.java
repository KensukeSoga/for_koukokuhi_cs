package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.integ.DaoFactory;

/**
*
* <P>xxx<P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2016/03/10 HDX�Ή� HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterLogMaterialListCmnOADAOFactory extends DaoFactory {

	/**
	 * �C���X�^���X�֎~�̂��߁Aprivate�ɂĎ���
	 */
	private RegisterLogMaterialListCmnOADAOFactory() {

	}

	/**
	 * RegisterLogMaterialListCmnOADAO���擾���܂�
	 * @return
	 */
	public static RegisterLogMaterialListCmnOADAO createLogMaterialListCmnOADAO() {
		return (RegisterLogMaterialListCmnOADAO) DaoFactory.createDao(RegisterLogMaterialListCmnOADAO.class);
	}
}
