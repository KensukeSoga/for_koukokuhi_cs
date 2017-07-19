package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�ύX���O��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindAccountBookLogCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �䒠No */
    private String _daichono = null;

    /**
     * �䒠No���擾����
     *
     * @return �䒠No
     */
    public String getDaichono() {
        return _daichono;
    }

    /**
     * �䒠No��ݒ肷��
     *
     * @param daichono �䒠No
     */
    public void setDaichono(String daichono) {
        this._daichono = daichono;
    }

}
