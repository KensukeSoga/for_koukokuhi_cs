package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���W�I�ǑI����ʌ�������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimtoo)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdStationSelectCondition implements Serializable{

    private static final long serialVersionUID = 1L;

    /** ���ID */
    private String _formID = null;

    /**
     * ���ID���擾����
     * @return String ���ID
     */
    public String getFormID() {
        return _formID;
    }

    /**
     * ���ID��ݒ肷��
     * @param val String ���ID
     */
    public void setFormID(String val) {
        _formID = val;
    }

}
