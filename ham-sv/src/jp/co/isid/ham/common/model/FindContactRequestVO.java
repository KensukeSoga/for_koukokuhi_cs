package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �˗���VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/08/02 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindContactRequestVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindContactRequestVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new FindContactRequestVO();
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
}
