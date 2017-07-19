package jp.co.isid.ham.media.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �c�ƍ�Ƒ䒠���[�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/20 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindAccountBookOutputCondition implements Serializable{

    /** serialVersionUID */
   private static final long serialVersionUID = 1L;

   /** �S����ID */
   private String _hamid = null;

   /**
    * �S����ID���擾����
    *
    * @return �S����ID
    */
   public String getHamid() {
       return _hamid;
   }

   /**
    * �S����ID��ݒ肷��
    *
    * @param hamid �S����ID
    */
   public void setHamid(String hamid) {
       this._hamid = hamid;
   }
}
