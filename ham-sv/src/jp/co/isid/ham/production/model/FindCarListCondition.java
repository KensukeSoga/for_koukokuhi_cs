package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �����t���Ԏ�}�X�^�擾�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/03/27 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCarListCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = -1626802308467753490L;

    /** �S����ID */
    private String _hamid = null;

    /** ��� */
    private String _secType = null;

    /**
     * �S����ID���擾����.
     * @return �S����ID
     */
    @XmlElement(required = true)
    public String get_hamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��.
     * @param hamid �S����ID
     */
    public void set_hamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * ��ʂ��擾����.
     * @return ���
     */
    @XmlElement(required = true)
    public String get_secType() {
        return _secType;
    }

    /**
     * ��ʂ�ݒ肷��.
     * @param secType ���
     */
    public void set_secType(String secType) {
        this._secType = secType;
    }


}
