package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ������f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/03/26 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class CheckListThsDataVO extends AbstractModel {

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public CheckListThsDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new CheckListThsDataVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYCD, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.STARTYMD, val);
    }

    /**
     * ������Ɩ��i���������j���擾����
     *
     * @return ������Ɩ��i���������j
     */
    public String getTHSKGYLNGKJ() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
    }

    /**
     * ������Ɩ��i���������j��ݒ肷��
     *
     * @param val ������Ɩ��i���������j
     */
    public void setTHSKGYLNGKJ(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYLNGKJ, val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SEQNO);
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SEQNO, val);
    }

    /**
     * �T�u�����擾����
     *
     * @return �T�u��
     */
    public String getSUBMEI() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBMEI);
    }

    /**
     * �T�u����ݒ肷��
     *
     * @param val �T�u��
     */
    public void setSUBMEI(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBMEI, val);
    }
}
