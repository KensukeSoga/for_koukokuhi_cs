package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * BudgetDetailsDAO.findBudgetDetails�Ŏ擾�����f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/07 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCheckListHattyuKykVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCheckListHattyuKykVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindCheckListHattyuKykVO();
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getSIKCDKYK() {
        return (String) get("SIKCDKYK");
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param val �ǃR�[�h
     */
    public void setSIKCDKYK(String val) {
        set("SIKCDKYK", val);
    }

    /**
     * �ǖ����擾����
     *
     * @return ����
     */
    public String getKYOKUNM() {
        return (String) get("KYOKUNM");
    }

    /**
     * �ǖ���ݒ肷��
     *
     * @param val ����
     */
    public void setKYOKUNM(String val) {
        set("KYOKUNM", val);
    }

    /**
     * �˗���g�D�R�[�h���擾����
     *
     * @return �˗���g�D�R�[�h
     */
    public String getSIKCD() {
        return (String) get("SIKCD");
    }

    /**
     * �˗���g�D�R�[�h��ݒ肷��
     *
     * @param val �˗���g�D�R�[�h
     */
    public void setSIKCD(String val) {
        set("SIKCD", val);
    }
}
