package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �}�̏󋵊Ǘ��f�[�^�I����ʂ̌����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindMediaPlanSelectCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ID */
    private String _formID = null;

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormID() {
        return _formID;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formID ���ID
     */
    public void setFormID(String formID) {
        this._formID = formID;
    }
}
