package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �˗���i�荞��VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/10/01 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindContactRequestNarrowingVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindContactRequestNarrowingVO();
    }

    /**
     * �˗���R�[�h�擾
     *
     * @return �˗���R�[�h
     */
    public String getIRAISAKICODE() {
        return (String) get("IRAISAKICODE");
    }

    /**
     * �˗���R�[�h�ݒ�
     *
     * @param val �˗���R�[�h
     */
    public void setIRAISAKICODE(String val) {
        set("IRAISAKICODE", val);
    }

    /**
     * �˗��於�擾
     *
     * @return �˗��於
     */
    public String getIRAISAKINAME() {
        return (String) get("IRAISAKINAME");
    }

    /**
     * �˗��於�ݒ�
     *
     * @param val �˗��於
     */
    public void setIRAISAKINAME(String val) {
        set("IRAISAKINAME", val);
    }

    public String getDSIKKBNCD() {
        return (String) get("DSIKKBNCD");
    }

    public void setDSIKKBNCD(String val) {
        set("IRAISAKINAME", val);
    }

    public String getIRSKSHOWNO() {
        return (String) get("IRSKSHOWNO");
    }

    public void setIRSKSHOWNO(String val) {
        set("IRSKSHOWNO", val);
    }

    /**
     * �}�̎�ʃR�[�h�擾
     *
     * @return �}�̎�ʃR�[�h
     */
    public String getMEDIASCD() {
        return (String) get("MEDIASCD");
    }

    /**
     * �}�̎�ʃR�[�h�ݒ�
     *
     * @param val �}�̎�ʃR�[�h
     */
    public void setMEDIASCD(String val) {
        set("MEDIASCD", val);
    }

    /**
     * �\�[�g���擾
     * @return �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get("SORTNO");
    }

    /**
     * �\�[�g���ݒ�
     * @param val �\�[�g��
     */
    public void setSORTNO(BigDecimal val) {
        set("SORTNO", val);
    }
}
